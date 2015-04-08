package com.Grupo2.es2.Dados;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class InscricaoUC implements Parcelable {
	// Variables
	private int mId;
	private int mIdUC;
	private int mNumeroAluno;

	// Constructor
	public InscricaoUC(int id, int idUC, int numeroAluno){
		mId = id;
		mIdUC = idUC;
		mNumeroAluno = numeroAluno;
	}        // END of Constructor

	// Getters & Setters
	public int getId() {
		return mId;
	}

	public void setId(int id) {
		mId = id;
	}

	public int getIdUC() {
		return mIdUC;
	}

	public void setIdUC(int idUC) {
		mIdUC = idUC;
	}

	public int getNumeroAluno() {
		return mNumeroAluno;
	}

	public void setNumeroAluno(int numeroAluno) {
		mNumeroAluno = numeroAluno;
	}

	// Parcelables
	protected InscricaoUC(Parcel in) {
		mId = in.readInt();
		mIdUC = in.readInt();
		mNumeroAluno = in.readInt();
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeInt(mId);
		dest.writeInt(mIdUC);
		dest.writeInt(mNumeroAluno);
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