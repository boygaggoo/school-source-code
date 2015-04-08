package com.Grupo2.es2.Dados;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class InscricaoTurno implements Parcelable {
	// Variables
	private int mId;
	private int mNumeroAluno;
	private String mIdTurno;

	// Constructor
	public InscricaoTurno(int id, int numeroAluno, String idTurno){
		mId = id;
		mNumeroAluno = numeroAluno;
		mIdTurno = idTurno;
	}        // END of Constructor

	// Getters & Setters
	public int getId() {
		return mId;
	}

	public void setId(int id) {
		mId = id;
	}

	public int getNumeroAluno() {
		return mNumeroAluno;
	}

	public void setNumeroAluno(int numeroAluno) {
		mNumeroAluno = numeroAluno;
	}

	public String getIdTurno() {
		return mIdTurno;
	}

	public void setIdTurno(String idTurno) {
		mIdTurno = idTurno;
	}

	// Parcelables
	protected InscricaoTurno(Parcel in) {
		mId = in.readInt();
		mNumeroAluno = in.readInt();
		mIdTurno = in.readString();
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeInt(mId);
		dest.writeInt(mNumeroAluno);
		dest.writeString(mIdTurno);
	}

	@SuppressWarnings("unused")
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