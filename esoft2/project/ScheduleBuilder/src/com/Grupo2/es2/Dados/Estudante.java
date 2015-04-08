package com.Grupo2.es2.Dados;

import java.util.ArrayList;

import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class Estudante implements Parcelable {
	// Variables
	private int mId;
	private String mNome;
	private String mEmail;
	private ArrayList<UC> listaUcsInscritos;

	// Constructor
	public Estudante(int id, String nome, String email) {
		super();
		this.mId = id;
		this.mNome = nome;
		this.mEmail = email;
		this.listaUcsInscritos = new ArrayList<UC>();
	}			// END of Constructor

	// Getters & Setters
	public ArrayList<UC> getListaUcsInscritos() {
		return listaUcsInscritos;
	}

	public void setListaUcsInscritos(ArrayList<UC> listaUcsInscritos) {
		this.listaUcsInscritos = listaUcsInscritos;
	}
	
	public int getId() {
		return mId;
	}

	public void setId(int id) {
		mId = id;
	}

	public String getNome() {
		return mNome;
	}

	public void setNome(String nome) {
		mNome = nome;
	}

	public String getEmail() {
		return mEmail;
	}

	public void setEmail(String email) {
		mEmail = email;
	}

	protected Estudante(Parcel in) {
		mId = in.readInt();
		mNome = in.readString();
		mEmail = in.readString();
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeInt(mId);
		dest.writeString(mNome);
		dest.writeString(mEmail);
	}

	@SuppressWarnings("unused")
	public static final Parcelable.Creator<Estudante> CREATOR = new Parcelable.Creator<Estudante>() {
		@Override
		public Estudante createFromParcel(Parcel in) {
			return new Estudante(in);
		}

		@Override
		public Estudante[] newArray(int size) {
			return new Estudante[size];
		}
	};
}							// END of Class
