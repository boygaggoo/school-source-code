package com.Grupo2.es2.Dados;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class Docente implements Parcelable {
	// Variables
	private String mNome;

	// Constructor
	public Docente(String nome) {
		mNome = nome;
	}					// END of Constructor

	// Getters & Setters
	public String getNome() {
		return mNome;
	}

	public void setNome(String nome) {
		mNome = nome;
	}

	protected Docente(Parcel in) {
		mNome = in.readString();
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeString(mNome);
	}

	@SuppressWarnings("unused")
	public static final Parcelable.Creator<Docente> CREATOR = new Parcelable.Creator<Docente>() {
		@Override
		public Docente createFromParcel(Parcel in) {
			return new Docente(in);
		}

		@Override
		public Docente[] newArray(int size) {
			return new Docente[size];
		}
	};

}						// END of Class
