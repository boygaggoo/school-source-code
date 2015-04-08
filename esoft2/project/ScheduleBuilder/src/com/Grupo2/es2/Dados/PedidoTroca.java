package com.Grupo2.es2.Dados;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class PedidoTroca implements Parcelable {
	// Variables
	private int mId;
	private int mIdAluno;
	private String mIdTurnoAtual;
	private String mIdTurnoTrocar;

	// Constructor
	public PedidoTroca(int id, int idAluno, String idTurnoAtual, String idTurnoTrocar){
		mId = id;
		mIdAluno = idAluno;
		mIdTurnoAtual = idTurnoAtual;
		mIdTurnoTrocar = idTurnoTrocar;
	}        // END of Constructor
	

	// Getters & Setters
	public int getId() {
		return mId;
	}

	public void setId(int id) {
		mId = id;
	}

	public int getIdAluno() {
		return mIdAluno;
	}

	public void setNumeroAluno(int numeroAluno) {
		mIdAluno = numeroAluno;
	}

	public String getIdTurnoAtual() {
		return mIdTurnoAtual;
	}


	public void setIdTurnoAtual(String iddTurnoAtual) {
		mIdTurnoAtual = iddTurnoAtual;
	}


	public String getIdTurnoTrocar() {
		return mIdTurnoTrocar;
	}


	public void setIdTurnoTrocar(String idTurnoTrocar) {
		mIdTurnoTrocar = idTurnoTrocar;
	}


	// Parcelables
	protected PedidoTroca(Parcel in) {
		mId = in.readInt();
		mIdAluno = in.readInt();
		mIdTurnoAtual = in.readString();
		mIdTurnoTrocar = in.readString();
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeInt(mId);
		dest.writeInt(mIdAluno);
		dest.writeString(mIdTurnoAtual);
		dest.writeString(mIdTurnoTrocar);
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