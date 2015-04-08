package com.Grupo2.es2.BaseDados;



import java.util.ArrayList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

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
public class BaseDadosHelper extends SQLiteOpenHelper {
	private static final String DATABASE_NAME = "ScheduleBuilder.db";
	private static final int DATABASE_VERSION = 10;

	// tabela UCs
	public static final String TABLE_UC = "UCs";
	public static final String ID_UC = "id";
	public static final String NOME_UC = "nome";
	public static final String ABREVIATURA_UC = "abreviatura";
	public static final String CURSO_UC = "curso";
	public static final String REGIME_UC = "regime";
	public static final String ANO_UC = "ano";
	public static final String SEMESTRE_UC = "semestre";
	public static final String RESPONSAVEL_UC = "responsavel";

	// tabela TURNOS
	private static final String TABLE_TURNO = "Turnos";
	public static final String ID_TURNO = "id";
	public static final String IDUC_TURNO = "idUC";// chaveEstrangeira
	public static final String TIPO_TURNO = "tipo";
	public static final String NUMERO_TURNO = "numero";
	public static final String HORAINICIO_TURNO = "horaInicio";
	public static final String DURACAO_TURNO = "duracao";
	public static final String SALA_TURNO = "sala";
	public static final String DIA_TURNO = "dia";
	public static final String DOCENTE_TURNO = "docente";

	// tabela Estudantes
	private static final String TABLE_ESTUDANTE = "Estudantes";
	public static final String ID_ESTUDANTE = "id";
	public static final String NOME_ESTUDANTE = "nome";
	public static final String EMAIL_ESTUDANTE = "email";

	// tabela InscricoesUcs
	private static final String TABLE_INSCRICOESUC = "InscricoesUCs";
	public static final String ID_INSCRICOESUC = "id";
	public static final String NUMEROALUNO_INSCRICOESUC = "numeroAluno";// chaveEstrangeira
	public static final String IDUC_INSCRICOESUC = "idUC";// chaveEstrangeira

	// tabela InscricoesTurno
	private static final String TABLE_INSCRICOESTURNO = "InscricoesTurnos";
	public static final String ID_INSCRICOESTURNO = "id";
	public static final String NUMEROALUNO_INSCRICOESTURNO = "numeroAluno";// chaveEstrangeira
	public static final String IDTURNO_INSCRICOESTURNO = "idTurno";// chaveEstrangeira

	// tabela Pedidostroca
	private static final String TABLE_PEDIDOTROCA = "PedidosTroca";
	public static final String ID_PEDIDOTROCA = "id";
	public static final String NUMEROALUNO_PEDIDOTROCA = "idAluno";// chaveEstrangeira
	public static final String IDTURNOATUAL_PEDIDOTROCA = "idTurnoAtual";// chaveEstrangeira
	public static final String IDTURNOTROCAR_PEDIDOTROCA = "idTurnoTrocar";// chaveEstrangeira

	private static final String DATABASE_CREATE_TABLE_UC = 
	"CREATE TABLE " + TABLE_UC + "(" + ID_UC
	+ " INTEGER PRIMARY KEY," + NOME_UC + " TEXT,"
	+ ABREVIATURA_UC + " TEXT," + CURSO_UC + " TEXT,"
	+ REGIME_UC + " TEXT," + ANO_UC + " INTEGER," + SEMESTRE_UC
	+ " INTEGER," + RESPONSAVEL_UC + " TEXT);";
	
	private static final String DATABASE_CREATE_TABLE_TURNO = 
			"CREATE TABLE " + TABLE_TURNO + 
			"(" + ID_TURNO + " TEXT PRIMARY KEY," + IDUC_TURNO + 
			" INTEGER," + TIPO_TURNO + " TEXT," + NUMERO_TURNO +
			" INTEGER," + HORAINICIO_TURNO + " TEXT," + DURACAO_TURNO
			+ " TEXT," + SALA_TURNO + " TEXT," + DIA_TURNO + " INTEGER," 
			+ DOCENTE_TURNO + " TEXT);";
	
	private static final String DATABASE_CREATE_TABLE_ESTUDANTE = "create table " + TABLE_ESTUDANTE + "( " + ID_ESTUDANTE + " integer primary key, "
			+ NOME_ESTUDANTE + " text not null, " + EMAIL_ESTUDANTE + " text not null);";

	private static final String DATABASE_CREATE_TABLE_INSCRICOESUC = "create table " + TABLE_INSCRICOESUC + "( " + ID_INSCRICOESUC
			+ " integer primary key, " + NUMEROALUNO_INSCRICOESUC + " integer, " + IDUC_INSCRICOESUC + " integer)";
	
	private static final String DATABASE_CREATE_TABLE_INSCRICOESTURNO = "create table " + TABLE_INSCRICOESTURNO + "( " + ID_INSCRICOESTURNO
			+ " integer primary key, " + NUMEROALUNO_INSCRICOESTURNO + " integer, " + IDTURNO_INSCRICOESTURNO + " text)";
	private static final String DATABASE_CREATE_TABLE_PEDIDOTROCA = "create table " + TABLE_PEDIDOTROCA + "( " + ID_PEDIDOTROCA
			+ " integer primary key, " + NUMEROALUNO_PEDIDOTROCA + " integer, " + IDTURNOATUAL_PEDIDOTROCA + " text," + IDTURNOTROCAR_PEDIDOTROCA
			+ " text)";

	public BaseDadosHelper(Context context) {
		super(context, DATABASE_NAME, null, DATABASE_VERSION);
	}

	@Override
	public void onCreate(SQLiteDatabase db) {
		db.execSQL(DATABASE_CREATE_TABLE_UC);
		db.execSQL(DATABASE_CREATE_TABLE_TURNO);
		db.execSQL(DATABASE_CREATE_TABLE_ESTUDANTE);
		db.execSQL(DATABASE_CREATE_TABLE_INSCRICOESUC);
		db.execSQL(DATABASE_CREATE_TABLE_INSCRICOESTURNO);
		db.execSQL(DATABASE_CREATE_TABLE_PEDIDOTROCA);

	}

	public void hardDrop() {
		SQLiteDatabase db = this.getWritableDatabase();
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_UC);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_TURNO);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_ESTUDANTE);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_INSCRICOESUC);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_INSCRICOESTURNO);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_PEDIDOTROCA);
		onCreate(db);
	}
	
	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		Log.w(BaseDadosHelper.class.getName(), "Upgrading database from version " + oldVersion + " to " + newVersion
				+ ", which will destroy all old data");
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_UC);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_TURNO);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_ESTUDANTE);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_INSCRICOESUC);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_INSCRICOESTURNO);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_PEDIDOTROCA);
		onCreate(db);
	}
	
	// Manual Methods
	public int getVersion(){
		return DATABASE_VERSION;
	}
	
	// Query
	public UC getUC (int idUC){
		  SQLiteDatabase db = this.getWritableDatabase();
		  String[] allColumnsUCs = {ID_UC, NOME_UC, ABREVIATURA_UC, CURSO_UC, REGIME_UC, ANO_UC, SEMESTRE_UC, RESPONSAVEL_UC};
		  Cursor cursor = db.query(TABLE_UC, allColumnsUCs, ID_UC + " = " + idUC, null,null, null, null);
		  UC uc= new UC(Integer.parseInt(cursor.getString(0)),cursor.getString(1),cursor.getString(2),cursor.getString(3),cursor.getString(4),Integer.parseInt(cursor.getString(5)),Integer.parseInt(cursor.getString(6)),cursor.getString(7));
		  // Returned UC
		  return uc;
	  }


	public void addUC(UC uc) {
		SQLiteDatabase baseDados = this.getWritableDatabase();
		ContentValues values = new ContentValues();
		values.put(ID_UC, uc.getId());
		values.put(NOME_UC,uc.getNomeUC());
		values.put(ABREVIATURA_UC, uc.getAbreviatura());
		values.put(CURSO_UC, uc.getCurso());
		values.put(REGIME_UC, uc.getRegime());
		values.put(ANO_UC, uc.getAno());
		values.put(SEMESTRE_UC, uc.getSemestre());
		values.put(RESPONSAVEL_UC, uc.getResponsavel());

		baseDados.insert(TABLE_UC, null, values);
		baseDados.close();
		
	}

	public void addTurno(Turno turno) {
		SQLiteDatabase baseDados = this.getWritableDatabase();
		ContentValues values = new ContentValues();
		values.put(ID_TURNO, turno.getId());
		values.put(IDUC_TURNO, turno.getIdUC());
		values.put(TIPO_TURNO, turno.getTipo());
		values.put(NUMERO_TURNO, turno.getNumero());
		values.put(HORAINICIO_TURNO, turno.getHoraInicio());
		values.put(DURACAO_TURNO, turno.getDuracao());
		values.put(SALA_TURNO, turno.getSala());
		values.put(DIA_TURNO, turno.getDia());
		values.put(DOCENTE_TURNO, turno.getDocente());

		baseDados.insert(TABLE_TURNO, null, values);
		baseDados.close();

	}

	public void addEstudante(Estudante estudante) {
		SQLiteDatabase baseDados = this.getWritableDatabase();
		ContentValues values = new ContentValues();
		values.put(ID_ESTUDANTE, estudante.getId());
		values.put(NOME_ESTUDANTE, estudante.getNome());
		values.put(EMAIL_ESTUDANTE, estudante.getEmail());

		baseDados.insert(TABLE_ESTUDANTE, null, values);
		baseDados.close();

	}

	public void addInscricoesUCs(InscricaoUC inscricaoUC) {
		SQLiteDatabase baseDados = this.getWritableDatabase();
		ContentValues values = new ContentValues();
		values.put(ID_INSCRICOESUC,inscricaoUC.getId());
		values.put(NUMEROALUNO_INSCRICOESUC, inscricaoUC.getNumeroAluno());
		values.put(IDUC_INSCRICOESUC, inscricaoUC.getIdUC());

		baseDados.insert(TABLE_INSCRICOESUC, null, values);
		baseDados.close();

	}

	public void addInscricoesTurno(InscricaoTurno inscricaoTurno) {
		SQLiteDatabase baseDados = this.getWritableDatabase();
		ContentValues values = new ContentValues();
		values.put(ID_INSCRICOESTURNO, inscricaoTurno.getId());
		values.put(NUMEROALUNO_INSCRICOESTURNO, inscricaoTurno.getNumeroAluno());
		values.put(IDTURNO_INSCRICOESTURNO, inscricaoTurno.getIdTurno());

		baseDados.insert(TABLE_INSCRICOESTURNO, null, values);
		baseDados.close();

	}

	public void addPedidosTroca(PedidoTroca pedidoTroca) {
		SQLiteDatabase baseDados = this.getWritableDatabase();
		ContentValues values = new ContentValues();
		values.put(ID_PEDIDOTROCA, pedidoTroca.getId());
		values.put(NUMEROALUNO_PEDIDOTROCA, pedidoTroca.getIdAluno());
		values.put(IDTURNOATUAL_PEDIDOTROCA, pedidoTroca.getIdTurnoAtual());
		values.put(IDTURNOTROCAR_PEDIDOTROCA, pedidoTroca.getIdTurnoTrocar());
		baseDados.insert(TABLE_PEDIDOTROCA, null, values);
		baseDados.close();

	}

	public ArrayList<UC> getAllUCsPorEstudante(int iDEstudante) {		// Needs correction
		ArrayList<UC> ucList = new ArrayList<UC>();
	    // Query
	    String selectQuery = "SELECT u."+ID_UC+", u."+NOME_UC+", u."+ABREVIATURA_UC+", u."+CURSO_UC+", u."+REGIME_UC+", u."+ANO_UC+", u."+SEMESTRE_UC+", u."+RESPONSAVEL_UC+
	    					 " FROM " + TABLE_ESTUDANTE+" e, "+ TABLE_UC+ "u WHERE u."+iDEstudante+"=e."+iDEstudante;
	 
	    SQLiteDatabase db = this.getReadableDatabase();
	    Cursor cursor = db.rawQuery(selectQuery, null);
	 
	 
	    if (cursor.moveToFirst()) {
	        do {
	        	UC uc= new UC(Integer.parseInt(cursor.getString(0)),cursor.getString(1),cursor.getString(2),cursor.getString(3),cursor.getString(4),Integer.parseInt(cursor.getString(5)),Integer.parseInt(cursor.getString(6)),cursor.getString(7));
	            ucList.add(uc);
	        } while (cursor.moveToNext());
	    }
	 
	    // return uc list
	    return ucList;
	}
	
	public Turno getTurnoPorUCDeUmEstudante(int iDEstudante, int idUC) {
		
			// Query
		  	
		 
		    SQLiteDatabase db = this.getReadableDatabase();
		    
		    String selectQuery = "SELECT "+ID_TURNO+","+IDUC_TURNO+","+TIPO_TURNO+","+NUMERO_TURNO+","+HORAINICIO_TURNO+","+DURACAO_TURNO+","+SALA_TURNO+","+DIA_TURNO+","+DOCENTE_TURNO+
					 "FROM " + TABLE_TURNO+" t"+TABLE_INSCRICOESTURNO+" i WHERE "+idUC+"= t."+IDUC_TURNO+" AND t-"+ID_TURNO+" = i."+IDTURNO_INSCRICOESTURNO+" AND i."+NUMEROALUNO_INSCRICOESTURNO+"="+iDEstudante;
	
	        Log.e("turno a que o aluno esta inscrito numa determinada UC", selectQuery);
	 
	        Cursor c = db.rawQuery(selectQuery, null);
	 
	        if (c != null){
	        	c.moveToFirst(); 
	        }
	            
	        Turno turno = new Turno(c.getString(c.getColumnIndex(ID_TURNO)),c.getInt(c.getColumnIndex(IDUC_TURNO)),c.getString(c.getColumnIndex(TIPO_TURNO)),
	        		c.getInt(c.getColumnIndex(NUMERO_TURNO)),c.getString(c.getColumnIndex(HORAINICIO_TURNO)),c.getString(c.getColumnIndex(DURACAO_TURNO)),c.getString(c.getColumnIndex(SALA_TURNO)),
	        		c.getInt(c.getColumnIndex(DIA_TURNO)),c.getString(c.getColumnIndex(DOCENTE_TURNO)));
	        		
	            
		    return turno;
	}
	
	public ArrayList<UC> getAllUcs() {
		ArrayList<UC> ucList = new ArrayList<UC>();
	    // Query
	    String selectQuery = "SELECT "+ID_UC+","+NOME_UC+","+ABREVIATURA_UC+","+CURSO_UC+","+REGIME_UC+","+ANO_UC+","+SEMESTRE_UC+","+RESPONSAVEL_UC+
	    					 " FROM " + TABLE_UC;
	 
	    SQLiteDatabase db = this.getWritableDatabase();
	    Cursor cursor = db.rawQuery(selectQuery, null);
	 
	 
	    if (cursor.moveToFirst()) {
	        do {
	        	UC uc= new UC(Integer.parseInt(cursor.getString(0)),cursor.getString(1),cursor.getString(2),cursor.getString(3),cursor.getString(4),Integer.parseInt(cursor.getString(5)),Integer.parseInt(cursor.getString(6)),cursor.getString(7));
	            ucList.add(uc);
	        } while (cursor.moveToNext());
	    }
	 
	    // return contact list
	    return ucList;
	}
	
	public List<Turno> getAllTurnos() {
	    List<Turno> turnoList = new ArrayList<Turno>();
	    // Query
	    String selectQuery = "SELECT "+ID_TURNO+","+IDUC_TURNO+","+TIPO_TURNO+","+NUMERO_TURNO+","+HORAINICIO_TURNO+","+DURACAO_TURNO+","+SALA_TURNO+","+DIA_TURNO+","+DOCENTE_TURNO+
	    					 " FROM " + TABLE_TURNO;
	 
	    SQLiteDatabase db = this.getWritableDatabase();
	    Cursor cursor = db.rawQuery(selectQuery, null);
	 
	    if (cursor.moveToFirst()) {
	        do {
	        	Turno turno = new Turno(cursor.getString(0),Integer.parseInt(cursor.getString(1)),cursor.getString(2),Integer.parseInt(cursor.getString(3)),cursor.getString(4),cursor.getString(5),cursor.getString(6),Integer.parseInt(cursor.getString(7)),cursor.getString(8));
	        	turnoList.add(turno);
	        } while (cursor.moveToNext());
	    }
	 
	    // return contact list
	    return turnoList;
	}
	
	
	
	public ArrayList<Turno> getAllTurnosPorUC(int idUC) {  
		ArrayList<Turno> turnoList = new ArrayList<Turno>();
	    // Query
			String selectQuery = "SELECT "+ID_TURNO+","+IDUC_TURNO+","+TIPO_TURNO+","+NUMERO_TURNO+","+HORAINICIO_TURNO+","+DURACAO_TURNO+","+SALA_TURNO+","+DIA_TURNO+","+DOCENTE_TURNO+
			" FROM " + TABLE_TURNO+" WHERE "+IDUC_TURNO+"="+idUC;
			Log.i("Query - ", selectQuery);
		
		SQLiteDatabase db = this.getReadableDatabase();
		Cursor cursor = db.rawQuery(selectQuery, null);
		
		if (cursor.moveToFirst()) {
			do {
				Turno turno = new Turno(cursor.getString(0),Integer.parseInt(cursor.getString(1)),cursor.getString(2),Integer.parseInt(cursor.getString(3)),cursor.getString(4),cursor.getString(5),cursor.getString(6),Integer.parseInt(cursor.getString(7)),cursor.getString(8));
				Log.i("Turno - ", turno.getTipo());
				turnoList.add(turno);
			 } while (cursor.moveToNext());
	     }
		  
     return turnoList;
	 }
	
	public List<Estudante> getAllEstudantes() {
	    List<Estudante> estudantesList = new ArrayList<Estudante>();
	    // Query
	    String selectQuery = "SELECT "+ID_ESTUDANTE+","+NOME_ESTUDANTE+","+EMAIL_ESTUDANTE+" FROM " + TABLE_ESTUDANTE;
	 
	    SQLiteDatabase db = this.getReadableDatabase();
	    Cursor cursor = db.rawQuery(selectQuery, null);
	 
	    if (cursor.moveToFirst()) {
	        do {
	        	Estudante estudante= new Estudante(Integer.parseInt(cursor.getString(0)),cursor.getString(1),cursor.getString(2));
	        	estudantesList.add(estudante);
	        } while (cursor.moveToNext());
	    }
	 
	    return estudantesList;
	}

	public int getIDEstudantePorEmail(String email) {		// needs correction
	    // Query
	    String selectQuery = "SELECT "+ID_ESTUDANTE+","+NOME_ESTUDANTE+","+EMAIL_ESTUDANTE+" FROM " + TABLE_ESTUDANTE +
	    					" WHERE "+EMAIL_ESTUDANTE +" = '"+email+"'";
	 
	    //Log.e(TABLE_ESTUDANTE, selectQuery);
	    SQLiteDatabase db = this.getReadableDatabase();
	    Cursor cursor = db.rawQuery(selectQuery, null);
	 
	    if (cursor!=null) {
	        cursor.moveToFirst();
	    }
	        	Estudante estudante= new Estudante(Integer.parseInt(cursor.getString(0)),cursor.getString(1),cursor.getString(2));
	        
	 
	    return estudante.getId();
	}
	
	//INSCRICOESUC
	public List<InscricaoUC> getAllInscricaoUCs() {
	    List<InscricaoUC> inscricoesUC = new ArrayList<InscricaoUC>();
	    // Query
	    String selectQuery = "SELECT "+ID_INSCRICOESUC+","+NUMEROALUNO_INSCRICOESUC+","+IDUC_INSCRICOESUC+" FROM " + TABLE_INSCRICOESUC;
	 
	    SQLiteDatabase db = this.getReadableDatabase();
	    Cursor cursor = db.rawQuery(selectQuery, null);
	 
	    if (cursor.moveToFirst()) {
	        do {
	        	
	        	InscricaoUC inscricaoUC = new InscricaoUC(Integer.parseInt(cursor.getString(0)), Integer.parseInt(cursor.getString(1)), Integer.parseInt(cursor.getString(2)));
	        	inscricoesUC.add(inscricaoUC);
	        } while (cursor.moveToNext());
	    }
	 
	    return inscricoesUC;
	}
	//INSCRICOESTURNO
		public List<InscricaoTurno> getAllInscricoesTurnos() {
		    List<InscricaoTurno> inscricoesTurno = new ArrayList<InscricaoTurno>();
		    // Query
		    String selectQuery = "SELECT "+ID_INSCRICOESTURNO+","+NUMEROALUNO_INSCRICOESTURNO+","+IDTURNO_INSCRICOESTURNO+" FROM " + TABLE_INSCRICOESTURNO;
		 
		    SQLiteDatabase db = this.getReadableDatabase();
		    Cursor cursor = db.rawQuery(selectQuery, null);
		 
		    if (cursor.moveToFirst()) {
		        do {
		        	
		        	InscricaoTurno inscricaoTurno = new InscricaoTurno(Integer.parseInt(cursor.getString(0)), Integer.parseInt(cursor.getString(1)), cursor.getString(2));
		        	inscricoesTurno.add(inscricaoTurno);
		        } while (cursor.moveToNext());
		    }
		 
		    return inscricoesTurno;
		}
		
	//PEDIDOSTROCA
		//INSCRICOESTURNO
		public List<PedidoTroca> getAllPedidoTrocas() {
			List<PedidoTroca> pedidoTrocas = new ArrayList<PedidoTroca>();
			 // Query
			String selectQuery = "SELECT "+ID_PEDIDOTROCA+","+NUMEROALUNO_PEDIDOTROCA+","+IDTURNOATUAL_PEDIDOTROCA+","+IDTURNOTROCAR_PEDIDOTROCA+" FROM " + TABLE_PEDIDOTROCA;
				 
			SQLiteDatabase db = this.getReadableDatabase();
			Cursor cursor = db.rawQuery(selectQuery, null);
				 
			if (cursor.moveToFirst()) {
				do {
					PedidoTroca pedidoTroca = new PedidoTroca(Integer.parseInt(cursor.getString(0)),Integer.parseInt(cursor.getString(1)),cursor.getString(2),cursor.getString(3));
				    pedidoTrocas.add(pedidoTroca);
				} while (cursor.moveToNext());
			}
				 
			
			return pedidoTrocas;
		}
		
}
