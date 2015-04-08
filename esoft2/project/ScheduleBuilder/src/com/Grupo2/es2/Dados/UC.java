package com.Grupo2.es2.Dados;

import java.util.ArrayList;
import android.os.Parcel;
import android.os.Parcelable;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class UC implements Parcelable {
	// Variables
	private int mId;
	private String mNomeUC;
	private String mAbreviatura;
	private String mCurso;
	private String mRegime;
	private int mAno;
	private int mSemestre;
	private String mResponsavel;

	private ArrayList<Turno> mTurnos;

	// Constructor
	public UC(int id, String nomeUC, String abreviatura, String curso, String regime, int ano, int semestre, String responsavel) {
		mId = id;
		mNomeUC = nomeUC;
		mAbreviatura = abreviatura;
		mCurso = curso;
		mRegime = regime;
		mAno = ano;
		mSemestre = semestre;
		mResponsavel = responsavel;

		mTurnos = new ArrayList<Turno>();

	} // END of Constructor

	// Getters & Setters
	public int getId() {
		return mId;
	}

	public void setId(int id) {
		mId = id;
	}

	public String getNomeUC() {
		return mNomeUC;
	}

	public void setNomeUC(String nomeUC) {
		mNomeUC = nomeUC;
	}

	public String getAbreviatura() {
		return mAbreviatura;
	}

	public void setAbreviaturaCurso(String abreviatura) {
		mAbreviatura = abreviatura;
	}

	public String getCurso() {
		return mCurso;
	}

	public void setCurso(String curso) {
		mCurso = curso;
	}

	public String getRegime() {
		return mRegime;
	}

	public void setRegime(String regime) {
		mRegime = regime;
	}

	public int getAno() {
		return mAno;
	}

	public void setAno(int ano) {
		mAno = ano;
	}

	public int getSemestre() {
		return mSemestre;
	}

	public void setSemestre(int semestre) {
		mSemestre = semestre;
	}

	public String getResponsavel() {
		return mResponsavel;
	}

	public void setResponsavel(String responsavel) {
		mResponsavel = responsavel;
	}

	public ArrayList<Turno> getTurnos() {
		return mTurnos;
	}

	public void setTurnos(ArrayList<Turno> turnos) {
		mTurnos = turnos;
	}

	protected UC(Parcel in) {
		mId = in.readInt();
		mNomeUC = in.readString();
		mAbreviatura = in.readString();
		mCurso = in.readString();
		mRegime = in.readString();
		mAno = in.readInt();
		mSemestre = in.readInt();
		mResponsavel = in.readString();
		if (in.readByte() == 0x01) {
			mTurnos = new ArrayList<Turno>();
			in.readList(mTurnos, Turno.class.getClassLoader());
		} else {
			mTurnos = null;
		}
	}

	@Override
	public int describeContents() {
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeInt(mId);
		dest.writeString(mNomeUC);
		dest.writeString(mAbreviatura);
		dest.writeString(mCurso);
		dest.writeString(mRegime);
		dest.writeInt(mAno);
		dest.writeInt(mSemestre);
		dest.writeString(mResponsavel);
		if (mTurnos == null) {
			dest.writeByte((byte) (0x00));
		} else {
			dest.writeByte((byte) (0x01));
			dest.writeList(mTurnos);
		}
	}

	@SuppressWarnings("unused")
	public static final Parcelable.Creator<UC> CREATOR = new Parcelable.Creator<UC>() {
		@Override
		public UC createFromParcel(Parcel in) {
			return new UC(in);
		}

		@Override
		public UC[] newArray(int size) {
			return new UC[size];
		}
	};
} // END of Class
