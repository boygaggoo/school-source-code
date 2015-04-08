package com.Dados.es2.test;

import android.test.ActivityInstrumentationTestCase2;
import android.widget.ListView;

import com.Grupo2.es2.Activities.MainActivity;
import com.Grupo2.es2.Activities.UCDetalheActivity;
import com.Grupo2.es2.Dados.UC;
import com.robotium.solo.Solo;

public class MainActivityTest extends
		ActivityInstrumentationTestCase2<MainActivity> {
	private UC ucTeste;
	private Solo solo;
	public MainActivityTest() {
		super(MainActivity.class);
	}

	@Override	// SETUP
	protected void setUp() throws Exception {
		super.setUp();
		solo = new Solo(getInstrumentation(), getActivity());
		ucTeste = new UC(80, "TesteUC", "Test", "EI", "D", 3, 2, "Testing");
	}

	// TEAR DOWN
	protected void tearDown() throws Exception {
		solo.finishOpenedActivities();
		super.tearDown();
	}
	
	
	// Tests
	
	// #1
	public void test1ListarUCs(){
		solo.waitForDialogToClose();
		solo.assertCurrentActivity("Main Activity", MainActivity.class);
		
		// Main Activity
		MainActivity main = (MainActivity) solo.getCurrentActivity();
		// get ListView from project
		ListView listaUCs = (ListView) solo.getView(com.Dados.es2.R.id.listViewUCs);
	
		assertNotNull(listaUCs);
		
		boolean flagErro = false;
		for(int i=0; i<listaUCs.getCount();i++){
			if(listaUCs.getItemAtPosition(i) != main.getDB().getAllUcs().get(i)){
				flagErro=true;
			}
		}
		
		assertTrue("Base dados e ListView não são iguais", flagErro==false);

	}
	
	// #2
	public void test2DetalhesUCComTurnos(){
		solo.waitForDialogToClose();
		solo.assertCurrentActivity("MainActivity", MainActivity.class);
		solo.searchText("Programação II");
//		solo.assertCurrentActivity("Detalhes UC", UCDetalheActivity.class);
//		UCDetalheActivity ucDetalhesActivity = (UCDetalheActivity) solo.getCurrentActivity();
//		
//		assertEquals(ucDetalhesActivity.findViewById(com.Dados.es2.R.id.turno_DetalheUC).toString(), "Programação II");
//		assertNotNull(ucDetalhesActivity.findViewById(com.Dados.es2.R.id.listViewTurnos));
		
	}
	// #4
	public void test4DetalhesUCSemTurnos(){
		solo.waitForDialogToClose();
		solo.assertCurrentActivity("MainActivity", MainActivity.class);
		solo.clickOnText("Análise Matemática");
		solo.assertCurrentActivity("Detalhes UC", UCDetalheActivity.class);
		UCDetalheActivity ucDetalhesActivity = (UCDetalheActivity) solo.getCurrentActivity();
		
		assertEquals(ucDetalhesActivity.findViewById(com.Dados.es2.R.id.turno_DetalheUC).toString(), "Análise Matemática");
		ListView listaTurnos = (ListView) ucDetalhesActivity.findViewById(com.Dados.es2.R.id.listViewTurnos);
		assertTrue(listaTurnos.getCount() == 0);
		
	}
	
	// #5
	public void test5UpdateDBAndListView(){
		// Main Activity
		MainActivity main = (MainActivity) solo.getCurrentActivity();
		
		solo.waitForDialogToClose();
		solo.assertCurrentActivity("Main Activity", MainActivity.class);
		main.getDB().addUC(ucTeste);
		assertNotNull(main.getDB().getUC(ucTeste.getId()));
		
		solo.getCurrentActivity().runOnUiThread(new Runnable() {   
			@Override
			public void run() {
				getActivity().actualizarListView();
				}
		  });  
		  	getInstrumentation().waitForIdleSync();
		
		solo.searchText("TesteUC");
		solo.clickOnText("TesteUC");
	}

}
