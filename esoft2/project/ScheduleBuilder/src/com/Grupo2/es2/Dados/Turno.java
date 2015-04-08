package com.Grupo2.es2.Dados;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class Turno implements Parcelable {
	// Variables
	public static final int DIURNO = 1;
	public static final int POS_LABORAL = 2;
	private String mId;
	private int mIdUC;
	private String mTipo;
	private int mNumero;
	private String mSala;
	private String mDocente;
	private String mHoraInicio;
	private String mDuracao;
	private int mDia;

	// Constructor
	public Turno(String id, int idUC, String tipo, int numero, String horaInicio, String duracao, String sala, int dia,
			String docente) {
		mId = id;
		mIdUC = idUC;
		mTipo = tipo;
		mNumero = numero;
		mHoraInicio = horaInicio;
		mDuracao = duracao;
		mSala = sala;
		mDia = dia;
		mDocente = docente;
	}        // END of Constructor

	// Getters & Setters
	public String getId() {
		return mId;
	}

	public void setId(String id) {
		mId = id;
	}

	public int getIdUC() {
		return mIdUC;
	}

	public void setIdUC(int idUC) {
		mIdUC = idUC;
	}

	public String getTipo() {
		return mTipo;
	}

	public void setTipo(String tipo) {
		mTipo = tipo;
	}

	public int getNumero() {
		return mNumero;
	}

	public void setNumero(int numero) {
		mNumero = numero;
	}

	public String getHoraInicio() {
		return mHoraInicio;
	}

	public void setHoraInicio(String horaInicio) {
		mHoraInicio = horaInicio;
	}

	public String getDuracao() {
		return mDuracao;
	}

	public void setDuracao(String duracao) {
		mDuracao = duracao;
	}

	public String getSala() {
		return mSala;
	}

	public void setmSala(String sala) {
		mSala = sala;
	}

	public int getDia() {
		return mDia;
	}

	public void setDia(int dia) {
		mDia = dia;
	}

	public String getDocente() {
		return mDocente;
	}

	public void setDocente(String docente) {
		mDocente = docente;
	}
	
	// Parcelable
	protected Turno(Parcel in) {
		mId = in.readString();
		mIdUC = in.readInt();
		mTipo = in.readString();
		mNumero = in.readInt();
		mHoraInicio = in.readString();
		mDuracao = in.readString();
		mSala = in.readString();
		mDia = in.readInt();
		mDocente = in.readString();
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeString(mId);
		dest.writeInt(mIdUC);
		dest.writeString(mTipo);
		dest.writeInt(mNumero);
		dest.writeString(mHoraInicio);
		dest.writeString(mDuracao);
		dest.writeString(mSala);
		dest.writeInt(mDia);
		dest.writeString(mDocente);
	}

	public static final Parcelable.Creator<Turno> CREATOR = new Parcelable.Creator<Turno>() {
		@Override
		public Turno createFromParcel(Parcel in) {
			return new Turno(in);
		}

		@Override
		public Turno[] newArray(int size) {
			return new Turno[size];
		}
	};

}         // END of Class