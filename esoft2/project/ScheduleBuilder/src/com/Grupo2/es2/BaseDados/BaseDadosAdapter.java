package com.Grupo2.es2.BaseDados;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;

/**
 * @authors Joaquim Ley - 2121465 | Tiago Coito - 2111227
 * @UC Engenharia de Software II
 * @project Schedule Builder (SB)
 */
public class BaseDadosAdapter {
	private SQLiteDatabase baseDados;
	private BaseDadosHelper bd;

//	private String[] allColumns = { DbHelper.ID, DbHelper.NOME, DbHelper.EMAIL,DbHelper.TELEFONE, DbHelper.FOTO};

	public BaseDadosAdapter(Context context) {
		bd = new BaseDadosHelper(context);
	}

}
