using System;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;

namespace MoneyMeExport
{
	public class MoneyMeQuery
	{
		private string dbName;
		private SqliteConnection dbConn = null;
		private ArrayList queryResult = null;
		private string queryStatement = null;
		private DateTime? startDate = null;
		private DateTime? endDate = null;

		public MoneyMeQuery (string dbName)
		{
			this.dbName = dbName;
			this.dbConn = new SqliteConnection ("Data Source=" + this.dbName);
		}

		public void setStartDate (DateTime start)
		{
			this.startDate = start;
		}
		public void setEndDate (DateTime end)
		{
			this.endDate = end;
		}

		public DateTime getStartDate()
		{
			if (! this.startDate.HasValue) {
				this.startDate = new DateTime (DateTime.Now.Year, DateTime.Now.Month, 1);
			}
			return this.startDate.Value;
		}
		public DateTime getEndDate()
		{
			if (! this.endDate.HasValue) {
				this.endDate = DateTime.Now;
			}
			return this.endDate.Value;
		}

		private string getQueryStatement()
		{
			if (this.queryStatement == null) {
				string startDateStr = this.getStartDate ().ToString ("yyyy-MM-dd");
				string endDateStr = this.getEndDate ().ToString ("yyyy-MM-dd");

				this.queryStatement =  "SELECT m.mov_fecha, c.nombre_cat, m.mov_nombre, m. mov_cantidad, f.fp_nombre ";
				this.queryStatement += "FROM moviments m, categories c, forma_de_pago f ";
				this.queryStatement += "WHERE m.mov_fecha ";
				this.queryStatement += "BETWEEN \""+startDateStr+"\" AND \""+endDateStr+"\" ";
				this.queryStatement += "AND m.mov_categoria=c._id AND m.mov_id_forma_pago=f._id ";
				this.queryStatement += "ORDER BY mov_fecha ASC";

			}

			return this.queryStatement;
		}

		private string processDate(string date)
		{
			DateTime dt = DateTime.Parse (date);
			return dt.ToString ("d/M/yyy");
		}

		private string processPaymentMethod(string pm)
		{
			string retVal = pm;

			switch (pm) {
				case "Tickers":
					retVal = "Ti";
					break;
				case "Domiciliación bancaria":
					retVal = "D";
					break;
				case "Efectivo":
					retVal = "E";
					break;
				case "Tarj débito":
					retVal = "TD";
					break;
				case "Tarjeta":
					retVal = "TC";
					break;
				case "Paypal":
					retVal = "P";
					break;
			}
			return retVal;
		}

		private string processAmount(double amount)
		{
			var integerPart = Math.Floor (amount);
			var decimalPart = (amount - integerPart)*100;
			return integerPart.ToString () + "," + decimalPart.ToString ("00");
		}

		public ArrayList getResult()
		{
			if (this.queryResult == null) {
				this.dbConn.Open ();
				var command = this.dbConn.CreateCommand ();
				command.CommandText = this.getQueryStatement ();;
				SqliteDataReader dataReader = command.ExecuteReader ();

				this.queryResult = new ArrayList ();
				while (dataReader.Read()) {
					ArrayList currentRow = new ArrayList ();
					// Fecha del movimiento
					currentRow.Add (this.processDate(dataReader["mov_fecha"].ToString()));

					// Categoría del movimiento
					object nombre_cat = dataReader ["nombre_cat"];
					currentRow.Add (dataReader["nombre_cat"]);

					// Nombre del movimiento. Si es igual a la categoría, ponemos
					// string vacío. La igualdad se da si el usuario no puso nada
					// en el "nombre" de la app MoneyMe (o si escribió justo
					// el nombre de la categoría :D)
					object mov_nombre = dataReader ["mov_nombre"];
					if (nombre_cat.ToString().Equals (mov_nombre.ToString())) {
						currentRow.Add ("");
					} else {
						currentRow.Add (mov_nombre);
					}

					// Importe del movimiento
					currentRow.Add (this.processAmount(dataReader.GetDouble (dataReader.GetOrdinal ("mov_cantidad"))));

					// Forma de pago
					currentRow.Add (this.processPaymentMethod(dataReader["fp_nombre"].ToString()));

					// Agregar al resultado
					this.queryResult.Add (currentRow);
				}

				dataReader.Close ();
				this.dbConn.Close ();
			}
			return this.queryResult;
		}

		public override string ToString()
		{
			string retVal = "";
			ArrayList result = this.getResult ();

			retVal = "fecha;categoría;comentario;importe;forma pago\n";
			foreach (ArrayList row in result) {
				for (int i = 0; i < row.Count -1 ; i++) {
					retVal += row [i] + ";";
				}
				retVal += row[row.Count - 1];
				retVal += "\n";
			}
			return retVal;
		}

		public string ToCSV()
		{
			return this.ToString ();
		}
	}

}

