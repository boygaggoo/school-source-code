package com.Grupo2.es2.BaseDados;

import java.util.ArrayList;

import com.Grupo2.es2.Dados.Estudante;
import com.Grupo2.es2.Dados.InscricaoTurno;
import com.Grupo2.es2.Dados.InscricaoUC;
import com.Grupo2.es2.Dados.PedidoTroca;
import com.Grupo2.es2.Dados.Turno;
import com.Grupo2.es2.Dados.UC;


/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227 | Pedro Paixao - 2110126 | Telmo Matias - 2120164
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class BaseDados {
	// Variables
	private static ArrayList<UC> mUcs;
	private static ArrayList<Turno> mTurnos;
	private static ArrayList<Estudante> mEstudantes;
	private static ArrayList<InscricaoUC> mInsricoesUCs;
	private static ArrayList<InscricaoTurno> mInscricoesTurno;
	private static ArrayList<PedidoTroca> mPedidosTroca;
	private static BaseDadosHelper mDB;

	// Constructor
	public BaseDados(){
		mUcs = new ArrayList<UC>();
		mTurnos = new ArrayList<Turno>();
		mEstudantes = new ArrayList<Estudante>();
		mInsricoesUCs = new ArrayList<InscricaoUC>();
		mInscricoesTurno = new ArrayList<InscricaoTurno>();
		mPedidosTroca = new ArrayList<PedidoTroca>();;
	}							// END of Constructor 
	
	// Methods
	public static void addUC(UC uc){
		mUcs.add(uc);
	}
	// Getters & Setters
	public static BaseDadosHelper getDB() {
		return mDB;
	}

	public static void setDB(BaseDadosHelper db) {
		mDB = db;
	}
	
	public static ArrayList<UC> getUCs() {
		return mUcs;
	}

	public static void setUcs(ArrayList<UC> ucs) {
		mUcs = ucs;
	}

	public static ArrayList<Turno> getTurnos() {
		return mTurnos;
	}

	public static void setTurnos(ArrayList<Turno> turnos) {
		mTurnos = turnos;
	}

	public static ArrayList<Estudante> getEstudantes() {
		return mEstudantes;
	}

	public static void setEstudantes(ArrayList<Estudante> estudantes) {
		mEstudantes = estudantes;
	}

	public static ArrayList<InscricaoUC> getInsricoesUCs() {
		return mInsricoesUCs;
	}

	public static void setInsricoesUCs(ArrayList<InscricaoUC> insricoesUCs) {
		mInsricoesUCs = insricoesUCs;
	}

	public static ArrayList<InscricaoTurno> getInscricoesTurno() {
		return mInscricoesTurno;
	}

	public static void setInscricoesTurno(ArrayList<InscricaoTurno> inscricoesTurno) {
		mInscricoesTurno = inscricoesTurno;
	}

	public static ArrayList<PedidoTroca> getPedidosTroca() {
		return mPedidosTroca;
	}

	public static void setPedidosTroca(ArrayList<PedidoTroca> pedidosTroca) {
		mPedidosTroca = pedidosTroca;
	}
	
	// Methods
	
		
}								// END of Class
