package com.Grupo2.es2.Activities;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
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
public class TurnoDetalheActivity extends Activity {
	// Variables
	public static final String KEY_VISUALIZAR = "visualizar";
	private BaseDadosHelper db;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		
		// OnCreate
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_turnodetalhe);
		// Show the Up button in the action bar.
		setupActionBar();
		if (getIntent() != null) {
			Log.i("Get Selected Item from MainActivity", "SUCCESS!");
			
			// Init Database
			db = new BaseDadosHelper(getApplicationContext());

			Turno turnoSelecionado = (Turno) getIntent().getParcelableExtra(KEY_VISUALIZAR);
			if (turnoSelecionado != null) {
				prencherDetalhes(turnoSelecionado);
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
	private void prencherDetalhes(Turno turnoSelecionado) {
		((TextView) findViewById(R.id.turno_DetalheUC)).setText(getUCTurno(turnoSelecionado).getNomeUC());
		((TextView) findViewById(R.id.uc_DetalheResponsavel)).setText(turnoSelecionado.getDocente());
		((TextView) findViewById(R.id.turno_DetalheSala)).setText(turnoSelecionado.getSala());
		((TextView) findViewById(R.id.turno_DetalheHorario)).setText(gerirHorario(turnoSelecionado));
		((TextView) findViewById(R.id.turno_DetalheTipo)).setText(turnoSelecionado.getTipo()+turnoSelecionado.getNumero());
		
	}
	
	private UC getUCTurno(Turno turnoSelecionado){
		UC ucTurno = null;
		for (UC uc : db.getAllUcs()) {
			if(uc.getId() == turnoSelecionado.getIdUC()){
				ucTurno = uc;
			}
		}
		return ucTurno;
	}
	
	public String gerirHorario(Turno turnoSelecionado){		
		// Tratar Duracao
		String[] parts = turnoSelecionado.getDuracao().split(":");
		String part1 = parts[0];
		String part2 = parts[1];
		
		// Tratar HoraInicio
		String[] hora = turnoSelecionado.getHoraInicio().split(":");
		String hora1 = hora[0];
		String hora2 = hora[1];
		String horafim = Integer.toString((Integer.parseInt(hora1) + Integer.parseInt(part1)));
		return "Das " + hora1 + ":" + hora2 + " às " + horafim + ":" + part2 + " Sala: " + turnoSelecionado.getSala() + "\n" + turnoSelecionado.getDia() + "ª feiras";	
	}

}
