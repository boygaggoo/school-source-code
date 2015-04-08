package com.Grupo2.es2.Activities;

import java.io.IOException;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import uk.co.senab.actionbarpulltorefresh.library.PullToRefreshAttacher;
import uk.co.senab.actionbarpulltorefresh.library.PullToRefreshAttacher.OnRefreshListener;
import uk.co.senab.actionbarpulltorefresh.library.PullToRefreshLayout;
import android.accounts.AccountManager;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import com.Dados.es2.R;
import com.Grupo2.es2.BaseDados.BaseDadosHelper;
import com.Grupo2.es2.Dados.Estudante;
import com.Grupo2.es2.Dados.InscricaoTurno;
import com.Grupo2.es2.Dados.InscricaoUC;
import com.Grupo2.es2.Dados.PedidoTroca;
import com.Grupo2.es2.Dados.Turno;
import com.Grupo2.es2.Dados.UC;
import com.google.android.gms.auth.GoogleAuthException;
import com.google.android.gms.auth.UserRecoverableAuthException;
import com.google.api.client.googleapis.extensions.android.gms.auth.GoogleAccountCredential;
import com.google.gdata.client.spreadsheet.SpreadsheetService;
import com.google.gdata.data.spreadsheet.ListEntry;
import com.google.gdata.data.spreadsheet.ListFeed;
import com.google.gdata.data.spreadsheet.SpreadsheetEntry;
import com.google.gdata.data.spreadsheet.SpreadsheetFeed;
import com.google.gdata.data.spreadsheet.WorksheetEntry;
import com.google.gdata.util.ServiceException;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class MainActivity extends Activity implements OnItemClickListener, OnRefreshListener {
	// Variables
	private GoogleAccountCredential mCredencial;
	private SpreadsheetService mService;
	
	private static final String SPREADSHEET_SCOPE = "https://spreadsheets.google.com/feeds";

	private static final int REQUEST_CHOOSE_ACCOUNT = 1;
	private static final int REQUEST_ASK_PERMITION = 2;
	private static final int VISUALIZAR_UC = 3;
	
	private String mNomeSpreadsheet = "BaseDados";
	private String mAccount;
	private ListView mListaUCs;
	
	private BaseDadosHelper db;
	private boolean mEstarAutenticado = false;
	private PullToRefreshAttacher mPullToRefreshAttacher;
	
	// --- onCreate -- //
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		Log.i("onCreate", "Entered on Create");
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		initilizeComponents();
		verificarAutenticado();
		setupPullToRefresh();

	}					// END of onCreate

	// Methods
	private void setupPullToRefresh() {	// PullToRefresh lib
		mPullToRefreshAttacher = PullToRefreshAttacher.get(this);
		PullToRefreshLayout pullToRefresh = (PullToRefreshLayout) findViewById(R.id.pullToRefresh);
		pullToRefresh.setPullToRefreshAttacher(mPullToRefreshAttacher, this);
	}
	
	@Override
	public void onRefreshStarted(View view) {
		if(isOnline()){
			autenticarGoogle();
		}
		if(!isOnline()){
			actualizarListView();
		}
	}
	
	private void setRefreshDone() {
		if (mPullToRefreshAttacher.isRefreshing()) {
			mPullToRefreshAttacher.setRefreshComplete();
		}
	}

	private void setRefreshStart() {
		if (!mPullToRefreshAttacher.isRefreshing()) {
			mPullToRefreshAttacher.setRefreshing(true);
		}
	}	//--------------END of Pull to refresh Methods ------------//
	
	private void initilizeComponents() {
		db = new BaseDadosHelper(this); // DataBase
		mListaUCs = (ListView) findViewById(R.id.listViewUCs);
		mListaUCs.setOnItemClickListener(this);

		mService = new SpreadsheetService("SpikeSpreadsheet");
	}

	private void verificarAutenticado() {
		if (!mEstarAutenticado) {
			mCredencial = GoogleAccountCredential.usingOAuth2(this, SPREADSHEET_SCOPE);

			Intent itent = mCredencial.newChooseAccountIntent();
			startActivityForResult(itent, REQUEST_CHOOSE_ACCOUNT);
		}else{
			autenticarGoogle();
		}
	}
	
	private void autenticarGoogle() {
		if(isOnline()){
			mCredencial.setSelectedAccountName(mAccount);
			AsyncTask<Void, Void, Void> task = new AsyncTask<Void, Void, Void>() {
				@Override
				protected void onPreExecute() {
					setRefreshStart();
					super.onPreExecute();
				}
		
				@Override
				protected Void doInBackground(Void... params) {
					mCredencial.setSelectedAccountName(mAccount);
					try {
						mService.setAuthSubToken(mCredencial.getToken());
					} catch (UserRecoverableAuthException e) {
						startActivityForResult(e.getIntent(), REQUEST_ASK_PERMITION);
					} catch (IOException e) {
						e.printStackTrace();
					} catch (GoogleAuthException e) {
						e.printStackTrace();
					}
					return null;
				}
				
				// After Login download all data from Spreadsheet
				@Override
				protected void onPostExecute(Void result) {
					super.onPostExecute(result);
					Toast.makeText(getApplicationContext(), "Downloading", Toast.LENGTH_SHORT).show();
					obterUCsDaSpreadsheet();
					obterTurnosUCDaSpreadsheet();
					obterEstudantesDaSpreadsheet();
					obterInscricoesUCsDaSpreadsheet();
					obterInscricoesTurnosDaSpreadsheet();
					obterPedidosTrocaDaSpreadsheet();
					
				}
					
			};
		
			mEstarAutenticado = true;
			task.execute();
		} else{
			actualizarListView();
			setRefreshDone();
			new AlertDialog.Builder(this)
		    .setTitle("No Connection")
		    .setMessage("Erro: Não está ligado a Internet\nA informação apresentada poderá estar desactualizada!")
		    .setNeutralButton(android.R.string.ok, new DialogInterface.OnClickListener() {
		        public void onClick(DialogInterface dialog, int which) { 
		            dialog.cancel();
		        }
		     })
		    .setIcon(android.R.drawable.ic_dialog_alert)
		     .show();
		}
	}
	
	public void actualizarListView() { // Refresh ListView
		setRefreshStart();
		SimpleAdapter adapter = (SimpleAdapter) mListaUCs.getAdapter();
		adapter = null;

		List<Map<String, String>> data = new ArrayList<Map<String, String>>();
		Map<String, String> hashMap = null;
		int idEstudante = db.getIDEstudantePorEmail(mAccount);
		System.out.println(idEstudante);
		for (UC uc : db.getAllUCsPorEstudante(1)) {
			hashMap = new HashMap<String, String>(2);
			hashMap.put("Nome", uc.getNomeUC().toString());
			hashMap.put("Curso", uc.getCurso().toString());
			data.add(hashMap);
		}
		
		adapter = new SimpleAdapter(getApplicationContext(), data, R.layout.custom_black_listview, new String[] {
			"Nome", "Curso" }, new int[] {
			android.R.id.text1, android.R.id.text2 });

		mListaUCs.setAdapter(adapter);
	}
	
	// ------------------------- Download DATA to Local DB------------------ //
	// Manage Spreadsheet
	private SpreadsheetEntry obterSpreadsheetBlocking(String nome) {
		URL SPREADSHEET_FEED_URL = null;

		// Make a request to the API and get all spreadsheets.
		SpreadsheetFeed feed;
		try {
			SPREADSHEET_FEED_URL = new URL("https://spreadsheets.google.com/feeds/spreadsheets/private/full");
			feed = mService.getFeed(SPREADSHEET_FEED_URL, SpreadsheetFeed.class);
			List<SpreadsheetEntry> spreadsheets = feed.getEntries();

			// Iterate through all of the Spreadsheets returned
			for (SpreadsheetEntry spreadsheet : spreadsheets) {
				// Print the title of this spreadsheets to screen
				if (spreadsheet.getTitle().getPlainText().compareToIgnoreCase(nome) == 0) {
					return spreadsheet;
				}
			}

		} catch (IOException e) {
			e.printStackTrace();
		} catch (ServiceException e) {
			e.printStackTrace();
		}
		return null;
	}
	
	// ManageWorksheet
	protected WorksheetEntry getWorksheet(SpreadsheetEntry spreadsheet, String nome) {
		try {
			for (WorksheetEntry w : spreadsheet.getWorksheets()) {
				if (w.getTitle().getPlainText().compareToIgnoreCase(nome) == 0) {
					return w;
				}
			}
		} catch (IOException e) {
			e.printStackTrace();
		} catch (ServiceException e) {
			e.printStackTrace();
		}
		return null;
	}

	// Obter UCs
	protected void obterUCsDaSpreadsheet() {
		AsyncTask<Void, Void, List<UC>> task = new AsyncTask<Void, Void, List<UC>>() {

			@Override
			protected List<UC> doInBackground(Void... params) {
				SpreadsheetEntry spreadsheetBlocking = null;
				WorksheetEntry workSheetUCs = null;
			
				spreadsheetBlocking = obterSpreadsheetBlocking(mNomeSpreadsheet);
			
				if (spreadsheetBlocking != null) {
					workSheetUCs = getWorksheet(spreadsheetBlocking, "UCs");

				}
				if (workSheetUCs != null) {
					URL listFeedUrl = workSheetUCs.getListFeedUrl();
					ListFeed listFeed = null;

					try {
						listFeed = mService.getFeed(listFeedUrl, ListFeed.class);
					} catch (IOException e) {
						e.printStackTrace();
					} catch (ServiceException e) {
						e.printStackTrace();
					}
					
					db.hardDrop();
					for (ListEntry row : listFeed.getEntries()) {
						if (row != null) {
							 // Inserting UCs
					        Log.d("Insert: ", "Inserting .."); 
							UC uc = new UC(Integer.parseInt(row.getCustomElements().getValue("id")),
									row.getCustomElements().getValue("nome"), 
									row.getCustomElements().getValue("abreviatura"), 
									row.getCustomElements().getValue("curso"), 
									row.getCustomElements().getValue("regime"), 
									Integer.parseInt(row.getCustomElements().getValue("ano")), 
									Integer.parseInt(row.getCustomElements().getValue("semestre")), 
									row.getCustomElements().getValue("responsavel"));
						
							db.addUC(uc);
							Log.d("Insert: ", "Inserting .. "+uc.getNomeUC()); 
						} else {
							Toast.makeText(getApplicationContext(), "ERROR: Row is NULL", Toast.LENGTH_LONG).show();
						}
					}
				}
//				else {
//					mUCs = null;
//				}
				return db.getAllUcs();
			}

			@Override
			protected void onPostExecute(List<UC> result) {
				super.onPostExecute(result);
					if (result == null  ) {
					mListaUCs.setAdapter(null);
					Toast.makeText(getApplicationContext(), "ERROR: No data reterived", Toast.LENGTH_LONG).show();
				} else {
					//actualizarListView();
				}
				super.onPostExecute(result);
			}
		};
		task.execute();
	}
	
	// Obter Turnos
	protected void obterTurnosUCDaSpreadsheet(){
		AsyncTask<Void, Void, List<Turno>> tarefa = new AsyncTask<Void, Void, List<Turno>>() {

			@Override
			protected List<Turno> doInBackground(Void... params) {
				SpreadsheetEntry spreadsheetBlocking = null;
				WorksheetEntry workSheetTurnos = null;
			
				spreadsheetBlocking = obterSpreadsheetBlocking(mNomeSpreadsheet);
			
				if (spreadsheetBlocking != null) {
					workSheetTurnos = getWorksheet(spreadsheetBlocking, "Turnos");

				}
				if (workSheetTurnos != null) {
					URL listFeedUrl = workSheetTurnos.getListFeedUrl();
					ListFeed listFeed = null;
			
					try {
						listFeed = mService.getFeed(listFeedUrl, ListFeed.class);
						// iterate through each row, printing its cell values.
						for (ListEntry row : listFeed.getEntries()) {
							Turno turno = new Turno(row.getCustomElements().getValue("id"), 
									Integer.parseInt(row.getCustomElements().getValue("idUC")), 
									row.getCustomElements().getValue("tipo"), 
									Integer.parseInt(row.getCustomElements().getValue("numero")), 
									row.getCustomElements().getValue("horaInicio"), 
									row.getCustomElements().getValue("duracao"), 
									row.getCustomElements().getValue("sala"), 
									Integer.parseInt(row.getCustomElements().getValue("dia")), 
									row.getCustomElements().getValue("docente"));
							db.addTurno(turno);
							Log.d("Insert: ", "Inserting .. "+turno.getIdUC());
						}
					} catch (IOException e) {
						e.printStackTrace();
					} catch (ServiceException e) {
						e.printStackTrace();
					}
				}
				return db.getAllTurnos();
			}

			@Override
			protected void onPostExecute(List<Turno> result) {
				super.onPostExecute(result);
				if(result != null){
					Toast.makeText(getApplicationContext(), "Turnos Downloaded Sucess!", Toast.LENGTH_LONG).show();
					
				}
			}

		};
		tarefa.execute();
	}
	
	// Obter Estudantes
	protected void obterEstudantesDaSpreadsheet(){
		AsyncTask<Void, Void, List<Estudante>> tarefa = new AsyncTask<Void, Void, List<Estudante>>() {

			@Override
			protected List<Estudante> doInBackground(Void... params) {
				SpreadsheetEntry spreadsheetBlocking = null;
				WorksheetEntry worksheetEstudantes = null;
			
				spreadsheetBlocking = obterSpreadsheetBlocking(mNomeSpreadsheet);
			
				if (spreadsheetBlocking != null) {
					worksheetEstudantes = getWorksheet(spreadsheetBlocking, "Estudantes");

				}
				if (worksheetEstudantes != null) {
					URL listFeedUrl = worksheetEstudantes.getListFeedUrl();
					ListFeed listFeed = null;
			
					try {
						listFeed = mService.getFeed(listFeedUrl, ListFeed.class);
						// iterate through each row, printing its cell values.
						for (ListEntry row : listFeed.getEntries()) {
							Estudante estudante = new Estudante(Integer.parseInt(row.getCustomElements().getValue("id")), 
													row.getCustomElements().getValue("nome"), 
													row.getCustomElements().getValue("email"));
								
							db.addEstudante(estudante);
							Log.d("Insert: ", "Inserting .. "+estudante.getNome());
						}
					} catch (IOException e) {
						e.printStackTrace();
					} catch (ServiceException e) {
						e.printStackTrace();
					}
	
			
				}
				return db.getAllEstudantes();
			}
			@Override
			protected void onPostExecute(List<Estudante> result) {
				super.onPostExecute(result);
				if(result != null){
					Toast.makeText(getApplicationContext(), "Estudantes Downloaded Sucess!", Toast.LENGTH_LONG).show();
				}
			}

		};
		tarefa.execute();
	}
	
	
//	 Obter Inscricoes em UCs
	protected void obterInscricoesUCsDaSpreadsheet(){
		AsyncTask<Void, Void, List<InscricaoUC>> tarefa = new AsyncTask<Void, Void, List<InscricaoUC>>() {

			@Override
			protected List<InscricaoUC> doInBackground(Void... params) {
				SpreadsheetEntry spreadsheetBlocking = null;
				WorksheetEntry worksheetInscricoesUCs = null;
			
				spreadsheetBlocking = obterSpreadsheetBlocking(mNomeSpreadsheet);
			
				if (spreadsheetBlocking != null) {
					worksheetInscricoesUCs = getWorksheet(spreadsheetBlocking, "InscricoesUCs");

				}
				if (worksheetInscricoesUCs != null) {
					URL listFeedUrl = worksheetInscricoesUCs.getListFeedUrl();
					ListFeed listFeed = null;
			
					try {
						listFeed = mService.getFeed(listFeedUrl, ListFeed.class);
						// iterate through each row, printing its cell values.
						for (ListEntry row : listFeed.getEntries()) {
							InscricaoUC inscricao = new InscricaoUC(Integer.parseInt(row.getCustomElements().getValue("id")), 
														Integer.parseInt(row.getCustomElements().getValue("numeroAluno")), 
														Integer.parseInt(row.getCustomElements().getValue("idUC")));
									
							db.addInscricoesUCs(inscricao);
							Log.d("Insert: ", "Inserting .. "+inscricao.getIdUC());
						}
					} catch (IOException e) {
						e.printStackTrace();
					} catch (ServiceException e) {
						e.printStackTrace();
					}

				}
				return db.getAllInscricaoUCs();
			}

			@Override
			protected void onPostExecute(List<InscricaoUC> result) {
				super.onPostExecute(result);
				if(result == null){
					Toast.makeText(getApplicationContext(), "ERROR: Nothing retivered InscricoesUCs", Toast.LENGTH_LONG).show();
				}
			}

		};
		tarefa.execute();
	}

	protected void obterInscricoesTurnosDaSpreadsheet(){
		AsyncTask<Void, Void, List<InscricaoTurno>> tarefa = new AsyncTask<Void, Void, List<InscricaoTurno>>() {

			@Override
			protected List<InscricaoTurno> doInBackground(Void... params) {
				SpreadsheetEntry spreadsheetBlocking = null;
				WorksheetEntry worksheetInscricoesTurnos = null;
			
				spreadsheetBlocking = obterSpreadsheetBlocking(mNomeSpreadsheet);
			
				if (spreadsheetBlocking != null) {
					worksheetInscricoesTurnos = getWorksheet(spreadsheetBlocking, "InscricoesTurnos");

				}
				if (worksheetInscricoesTurnos != null) {
					URL listFeedUrl = worksheetInscricoesTurnos.getListFeedUrl();
					ListFeed listFeed = null;
			
					try {
					listFeed = mService.getFeed(listFeedUrl, ListFeed.class);
					// iterate through each row, printing its cell values.
						for (ListEntry row : listFeed.getEntries()) {
							InscricaoTurno inscricao = new InscricaoTurno(Integer.parseInt(row.getCustomElements().getValue("id")), 
														Integer.parseInt(row.getCustomElements().getValue("numeroAluno")), 
														row.getCustomElements().getValue("idTurno"));
									
							db.addInscricoesTurno(inscricao);
						}
					} catch (IOException e) {
						e.printStackTrace();
					} catch (ServiceException e) {
						e.printStackTrace();
					}
				}
				return db.getAllInscricoesTurnos();
			}

			@Override
			protected void onPostExecute(List<InscricaoTurno> result) {
				super.onPostExecute(result);
				if(result != null){
					Toast.makeText(getApplicationContext(), "InscricoesTurno Downloaded Sucess!", Toast.LENGTH_LONG).show();
				}
			}

		};
		tarefa.execute();
	}

	// Obter Pedidos de Troca
	protected void obterPedidosTrocaDaSpreadsheet(){
		AsyncTask<Void, Void, List<PedidoTroca>> tarefa = new AsyncTask<Void, Void, List<PedidoTroca>>() {

			@Override
			protected List<PedidoTroca> doInBackground(Void... params) {
				SpreadsheetEntry spreadsheetBlocking = null;
				WorksheetEntry worksheetPedidoTrocas = null;
			
				spreadsheetBlocking = obterSpreadsheetBlocking(mNomeSpreadsheet);
			
				if (spreadsheetBlocking != null) {
					worksheetPedidoTrocas = getWorksheet(spreadsheetBlocking, "PedidosTroca");

				}
				if (worksheetPedidoTrocas != null) {
					URL listFeedUrl = worksheetPedidoTrocas.getListFeedUrl();
					ListFeed listFeed = null;
			
					try {
						listFeed = mService.getFeed(listFeedUrl, ListFeed.class);
						// iterate through each row, printing its cell values.
						for (ListEntry row : listFeed.getEntries()) {
							PedidoTroca pedido = new PedidoTroca(Integer.parseInt(row.getCustomElements().getValue("id")), 
														Integer.parseInt(row.getCustomElements().getValue("idAluno")), 
														row.getCustomElements().getValue("idTurnoAtual"),
														row.getCustomElements().getValue("idTurnoTrocar"));
									
							db.addPedidosTroca(pedido);
						}
						
					} catch (IOException e) {
						e.printStackTrace();
					} catch (ServiceException e) {
						e.printStackTrace();
					}
				}
				return db.getAllPedidoTrocas();
			}

			@Override
			protected void onPostExecute(List<PedidoTroca> result) {
				super.onPostExecute(result);
				if(result != null){
					Toast.makeText(getApplicationContext(), "PedidosTrocas Downloaded Sucess!", Toast.LENGTH_LONG).show();
					actualizarListView();
					setRefreshDone();
				}
			}

		};
		tarefa.execute();
	}
	
	// --------------------------------- END OF DOWNLOADS ---------------------------- //
	
	public void verificarEstadoOnline(MenuItem item){
		isOnline();
		Toast.makeText(getApplicationContext(), "Checking...", Toast.LENGTH_SHORT).show();
		if(isOnline()){
			item.setIcon(R.drawable.high_connection);
			Toast.makeText(getApplicationContext(), "Device ONLINE", Toast.LENGTH_LONG).show();
		}else{
			item.setIcon(R.drawable.no_connection);
			Toast.makeText(getApplicationContext(), "Device OFFLINE", Toast.LENGTH_LONG).show();
		}
	}
	
	public BaseDadosHelper getDB(){
		return db;
	}
	
	public boolean isOnline() {
	    ConnectivityManager cm = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
	    NetworkInfo netInfo = cm.getActiveNetworkInfo();
	    if (netInfo != null && netInfo.isConnectedOrConnecting()) {
	        return true;
	    }
	    
	    return false;
	}
	
	@Override
	// - onActivityResult
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);
		if (requestCode == REQUEST_CHOOSE_ACCOUNT && resultCode == RESULT_OK) {
			mAccount = data.getStringExtra(AccountManager.KEY_ACCOUNT_NAME);
			if(!mEstarAutenticado){
				autenticarGoogle();
				mEstarAutenticado = true;
			}
		} else if (requestCode == REQUEST_ASK_PERMITION && resultCode == RESULT_OK) {
		//	autenticarGoogle();
		}
	}
	
	@Override
	public boolean onPrepareOptionsMenu(Menu menu) {
		verificarEstadoOnline(menu.findItem(R.id.action_status));
		return super.onPrepareOptionsMenu(menu);
	}
	
	@Override
	// - onCreateOptionsMenu
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	// - onItemClick
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle item selection
		switch (item.getItemId()) {
			case R.id.action_status:
				verificarEstadoOnline(item);
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	@Override
	public void onItemClick(AdapterView<?> l, View view, int position, long id) {
		
		UC ucSelecionada = db.getAllUcs().get(position);

		if (ucSelecionada != null) {
			Log.i("ucSelecionada", "Sucess");

			Intent intent = new Intent(MainActivity.this, UCDetalheActivity.class);
			intent.putExtra(UCDetalheActivity.KEY_VISUALIZAR, ucSelecionada);
			Log.i("PutExtra", "Sucess");
			startActivityForResult(intent, VISUALIZAR_UC);
			Log.i("startActivity", "Sucess");
		}
	}

}										// END of Class