package com.Grupo2.es2.Activities;


import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.NavUtils;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import com.Dados.es2.R;
import com.Grupo2.es2.BaseDados.BaseDadosHelper;
import com.Grupo2.es2.Dados.Turno;
import com.Grupo2.es2.Dados.UC;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class UCDetalheActivity extends Activity implements OnItemClickListener {
	// Variables
	public static final String KEY_VISUALIZAR = "visualizar";
	private ListView mTurnosUC;
	private BaseDadosHelper db;
	private static final int VISUALIZAR_TURNO = 1;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		
		// OnCreate
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_ucdetalhe);
		// Show the Up button in the action bar.
		setupActionBar();
		if (getIntent() != null) {
			Log.i("Get Selected Item from MainActivity", "SUCCESS!");
			
			mTurnosUC = (ListView) findViewById(R.id.listViewTurnos);
			mTurnosUC.setOnItemClickListener(this);
			
			// Init Database
			db = new BaseDadosHelper(getApplicationContext());

			UC ucSelecionada = (UC) getIntent().getParcelableExtra(KEY_VISUALIZAR);
			if (ucSelecionada != null) {
				prencherDetalhes(ucSelecionada);
			}
			 
		}

	}

	/**
	 * Set up the {@link android.app.ActionBar}.
	 */
	private void setupActionBar() {
		getActionBar().setDisplayHomeAsUpEnabled(true);

	}
	
	// Methods
	private void prencherDetalhes(UC ucSelecionada) {
		((TextView) findViewById(R.id.turno_DetalheUC)).setText(ucSelecionada.getNomeUC());
		((TextView) findViewById(R.id.turno_DetalheVagas)).setText(ucSelecionada.getCurso());
		((TextView) findViewById(R.id.uc_DetalheAno)).setText(Integer.toString(ucSelecionada.getAno()));
		((TextView) findViewById(R.id.turno_DetalheHorario)).setText(Integer.toString(ucSelecionada.getSemestre()));
		((TextView) findViewById(R.id.uc_DetalheResponsavel)).setText(ucSelecionada.getResponsavel());
		listarTurnos(ucSelecionada);
	}

	public void listarTurnos(UC ucSelecionada) { // Refresh ListView
		
		Log.i("UC - ", Integer.toString(ucSelecionada.getId()));
		SimpleAdapter adapter = (SimpleAdapter) mTurnosUC.getAdapter();
		adapter = null;

		List<Map<String, String>> data = new ArrayList<Map<String, String>>();
		Map<String, String> hashMap = null;
		
		for (Turno turno :db.getAllTurnosPorUC(ucSelecionada.getId())){
			Log.i("turno - ", turno.getTipo());
			hashMap = new HashMap<String, String>(2);
			hashMap.put("Nome", turno.getTipo().toString() + turno.getNumero());
			hashMap.put("Horario", gerirHorario(turno.getHoraInicio(), turno.getDuracao()) + " Sala: " + turno.getSala());
			data.add(hashMap);
		}
		
		adapter = new SimpleAdapter(getApplicationContext(), data, R.layout.custom_black_listview, new String[] {
			"Nome", "Horario" }, new int[] {
			android.R.id.text1, android.R.id.text2 });

		mTurnosUC.setAdapter(adapter);
	}
	
	public String gerirHorario(String horaInicio, String duracao){		
		// Tratar Duracao
		String[] parts = duracao.split(":");
		String part1 = parts[0];
		String part2 = parts[1];
		
		// Tratar HoraInicio
		String[] hora = horaInicio.split(":");
		String hora1 = hora[0];
		String hora2 = hora[1];
		String horafim = Integer.toString((Integer.parseInt(hora1) + Integer.parseInt(part1)));
		return hora1 + ":" + hora2 + " - " + horafim + ":" + part2;	
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.ucdetalhe, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
			case android.R.id.home:
				// This ID represents the Home or Up button. In the case of this
				// activity, the Up button is shown. Use NavUtils to allow users
				// to navigate up one level in the application structure. For
				// more details, see the Navigation pattern on Android Design:
				//
				// http://developer.android.com/design/patterns/navigation.html#up-vs-back
				//
				NavUtils.navigateUpFromSameTask(this);
				return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onItemClick(AdapterView<?> l, View view, int position, long id) {
		
		Turno turnoSelecionado = db.getAllTurnos().get(position);

		if (turnoSelecionado != null) {
			Log.i("turnoSelecionadO", "Sucess");

			Intent intent = new Intent(UCDetalheActivity.this, TurnoDetalheActivity.class);
			intent.putExtra(UCDetalheActivity.KEY_VISUALIZAR, turnoSelecionado);
			Log.i("PutExtra", "Sucess");
			startActivityForResult(intent, VISUALIZAR_TURNO);
			Log.i("startActivity", "Sucess");
		}
	}

}
