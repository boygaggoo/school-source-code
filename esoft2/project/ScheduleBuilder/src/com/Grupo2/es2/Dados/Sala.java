package com.Grupo2.es2.Dados;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class Sala implements Parcelable {
	// Variables
	private String mNome;

	// Constructor
	public Sala(String nome) {
		mNome = nome;
	}					// END of Constructor

	// Getters & Setters
	public String getNome() {
		return mNome;
	}

	public void setNome(String nome) {
		mNome = nome;
	}

	protected Sala(Parcel in) {
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
	public static final Parcelable.Creator<Sala> CREATOR = new Parcelable.Creator<Sala>() {
		@Override
		public Sala createFromParcel(Parcel in) {
			return new Sala(in);
		}

		@Override
		public Sala[] newArray(int size) {
			return new Sala[size];
		}
	};

}						// END of Class
