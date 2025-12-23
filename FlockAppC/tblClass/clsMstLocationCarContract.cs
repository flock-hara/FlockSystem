using FlockAppC.pubClass;
using System;
using System.Data;
using System.Text;

namespace FlockAppC.tblClass
{
    internal class ClsMstLocationCarContract
    {
        public int Location_id { get; set; }                    // Key
        public int Car_id {  get; set; }                        // Key
        public string Location_name { get; set; }
        public string No {  get; set; }
        public string Fullname { get; set; }
        public string Name { get; set; }
        public string Car_name { get; set; }
        public int Unit_price {  get; set; }
        public int Fuel_cost {  get; set; }
        public int Contract_km { get; set; }
        public int Burden_fee {  get; set; }

        private readonly StringBuilder sb = new();

        /// <summary>
        /// インスタンス
        /// </summary>
        public ClsMstLocationCarContract()
        {
            Location_id = 0;
            Car_id = 0;
            Location_name = "";
            No = "";
            Fullname = "";
            Name = "";
            Car_name = "";
            Unit_price = 0;
            Fuel_cost = 0;
            Contract_km = 0;
            Burden_fee = 0;
        }

        /// <summary>
        /// Select
        /// </summary>
        public void Select()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("SELECT");
                    sb.AppendLine(" Mst_専従先車両走行契約情報.id");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.location_id");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.location_car_id");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.unit_price");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.fuel_cost");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.contract_km");
                    sb.AppendLine(",Mst_専従先車両走行契約情報.burden_fee");
                    sb.AppendLine(",Mst_専従先.fullname AS location_fullname");
                    sb.AppendLine(",Mst_専従先車両.no");
                    sb.AppendLine(",Mst_専従先車両.fullname AS car_fullname");
                    sb.AppendLine(",Mst_専従先車両.name");
                    sb.AppendLine(",Mst_専従先車両.car_name");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Mst_専従先車両走行契約情報");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先車両走行契約情報.location_id = Mst_専従先.location_id");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("Mst_専従先車両");
                    sb.AppendLine("ON");
                    sb.AppendLine("Mst_専従先車両走行契約情報.location_car_id = Mst_専従先車両.id");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("Mst_専従先車両走行契約情報.location_id = " + Location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("Mst_専従先車両走行契約情報.location_car_id = " + Car_id);

                    using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                    {
                        foreach (DataRow dr in dt_val.Rows)
                        {
                            Location_name = dr["location_fullname"].ToString();
                            No = dr["no"].ToString();
                            Fullname = dr["car_fullname"].ToString();
                            Name = dr["name"].ToString();
                            Car_name = dr["car_name"].ToString();
                            if (dr["unit_price"] != null) { Unit_price = int.Parse(dr["unit_price"].ToString()); }
                            else { Unit_price = 0; }
                            if (dr["fuel_cost"] != null) { Fuel_cost = int.Parse(dr["fuel_cost"].ToString()); }
                            else { Fuel_cost = 0; }
                            if (dr["contract_km"] != null) { Contract_km = int.Parse(dr["contract_km"].ToString()); }
                            else { Contract_km = 0; }
                            if (dr["burden_fee"] != null) { Burden_fee = int.Parse(dr["burden_fee"].ToString()); }
                            else { Burden_fee = 0; }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Insert
        /// </summary>
        public void Insert()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先車両走行契約情報");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",location_car_id");
                    sb.AppendLine(",unit_price");
                    sb.AppendLine(",fuel_cost");
                    sb.AppendLine(",contract_km");
                    sb.AppendLine(",burden_fee");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Location_id.ToString());
                    sb.AppendLine("," + Car_id.ToString());
                    sb.AppendLine("," + Unit_price.ToString());
                    sb.AppendLine("," + Fuel_cost.ToString());
                    sb.AppendLine("," + Contract_km.ToString());
                    sb.AppendLine("," + Burden_fee.ToString());
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine(")");

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Insert　※INSERTしたレコードのIDを返す
        /// </summary>
        /// <returns>レコードID</returns>
        public int InsertScalar()
        {
            int new_id = -1;
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("INSERT INTO");
                    sb.AppendLine("Mst_専従先車両走行契約情報");
                    sb.AppendLine("(");
                    sb.AppendLine(" location_id");
                    sb.AppendLine(",location_car_id");
                    sb.AppendLine(",unit_price");
                    sb.AppendLine(",fuel_cost");
                    sb.AppendLine(",contract_km");
                    sb.AppendLine(",burden_fee");
                    // 2025/11/10↓
                    sb.AppendLine(",ins_user_id");
                    sb.AppendLine(",ins_date");
                    sb.AppendLine(",delete_flag");
                    // 2025/11/10↑
                    sb.AppendLine(") VALUES (");
                    sb.AppendLine(Location_id.ToString());
                    sb.AppendLine("," + Car_id.ToString());
                    sb.AppendLine("," + Unit_price.ToString());
                    sb.AppendLine("," + Fuel_cost.ToString());
                    sb.AppendLine("," + Contract_km.ToString());
                    sb.AppendLine("," + Burden_fee.ToString());
                    // 2025/11/10↓
                    sb.AppendLine("," + ClsLoginUser.StaffID);
                    sb.AppendLine(",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sb.AppendLine("," + ClsPublic.FLAG_OFF);
                    // 2025/11/10↑
                    sb.AppendLine("); SELECT SCOPE_IDENTITY();");

                    new_id = clsSqlDb.DMLUpdateScalar(sb.ToString());
                }
                return new_id;
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                return new_id;
                throw;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("UPDATE");
                    sb.AppendLine("Mst_専従先車両走行契約情報");
                    sb.AppendLine("SET");
                    sb.AppendLine(" unit_price = " + Unit_price);
                    sb.AppendLine(",fuel_cost = " + Fuel_cost);
                    sb.AppendLine(",contract_km = " + Contract_km);
                    sb.AppendLine(",burden_fee = " + Burden_fee);
                    // 2025/11/10↓
                    sb.AppendLine(",upd_user_id = " + ClsLoginUser.StaffID);
                    sb.AppendLine(",upd_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    // 2025/11/10↑
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + Location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("location_car_id = " + Car_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        public void Delete()
        {
            try
            {
                using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                {
                    sb.Clear();
                    sb.AppendLine("DELETE FROM");
                    sb.AppendLine("Mst_専従先車両走行契約情報");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("location_id = " + Location_id);
                    sb.AppendLine("AND");
                    sb.AppendLine("location_car_id = " + Car_id);

                    clsSqlDb.DMLUpdate(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先車両走行契約情報をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationCarContractData(ref System.Windows.Forms.ProgressBar p_pgb)
        {
            int rec_cnt;
            int importCnt = 0;

            try
            {
                using (ClsMySqlDb clsMySqlDb = new(ClsDbConfig.MySQLNo))
                {
                    /////////////////////////////////////////////////////////////////////////
                    // TRUNCATE TABLE
                    // 専従先車両走行契約情報テーブルをクリア
                    /////////////////////////////////////////////////////////////////////////
                    sb.Clear();
                    sb.AppendLine("TRUNCATE TABLE");
                    sb.AppendLine("Mst_専従先車両走行契約情報");

                    clsMySqlDb.DMLUpdate(sb.ToString());

                    /////////////////////////////////////////////////////////////////////////
                    // SQL Server → MySQL
                    /////////////////////////////////////////////////////////////////////////
                    using (ClsSqlDb clsSqlDb = new(ClsDbConfig.SQLServerNo))
                    {
                        // SQL Server SELECT ALL
                        // SQL Serverデータを読み込み、MySQLへ書き込む
                        sb.Clear();
                        sb.AppendLine("SELECT");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",location_car_id");
                        sb.AppendLine(",unit_price");
                        sb.AppendLine(",fuel_cost");
                        sb.AppendLine(",contract_km");
                        sb.AppendLine(",burden_fee");
                        // 2025/11/10↓
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        // 2025/11/10↑
                        sb.AppendLine("FROM");
                        sb.AppendLine("Mst_専従先車両走行契約情報");
                        sb.AppendLine("ORDER BY");
                        sb.AppendLine("id");

                        using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                        {
                            // ProgressBar設定
                            rec_cnt = dt_val.Rows.Count;
                            p_pgb.Visible = true;
                            p_pgb.Maximum = rec_cnt;

                            // MySQL INSERT
                            foreach (DataRow dr in dt_val.Rows)
                            {
                                sb.Clear();
                                sb.AppendLine("INSERT INTO Mst_専従先車両走行契約情報 (");
                                sb.AppendLine(" id");
                                sb.AppendLine(",location_id");
                                sb.AppendLine(",location_car_id");
                                sb.AppendLine(",unit_price");
                                sb.AppendLine(",fuel_cost");
                                sb.AppendLine(",contract_km");
                                sb.AppendLine(",burden_fee");
                                // 2025/11/10↓
                                sb.AppendLine(",ins_user_id");
                                sb.AppendLine(",ins_date");
                                sb.AppendLine(",upd_user_id");
                                sb.AppendLine(",upd_date");
                                sb.AppendLine(",delete_flag");
                                // 2025/11/10↑
                                sb.AppendLine(") VALUES (");
                                sb.AppendLine(dr["id"].ToString());
                                sb.AppendLine("," + dr["location_id"].ToString());
                                sb.AppendLine("," + dr["location_car_id"].ToString());
                                sb.AppendLine("," + dr["unit_price"].ToString());
                                sb.AppendLine("," + dr["fuel_cost"].ToString());
                                sb.AppendLine("," + dr["contract_km"].ToString());
                                sb.AppendLine("," + dr["burden_fee"].ToString());
                                // 2025/11/10↓
                                if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                                else { sb.AppendLine(",0"); }
                                if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                                else { sb.AppendLine(",0"); }
                                if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                                else { sb.AppendLine(",null"); }
                                if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                                else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                                // 2025/11/10↑
                                sb.AppendLine(")");

                                clsMySqlDb.DMLUpdate(sb.ToString());

                                importCnt++;

                                // ProgressBar値セット
                                p_pgb.Value = importCnt;
                                p_pgb.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 専従先車両走行契約情報をXServerのmySQLに登録
        /// </summary>
        public void ExportLocationOneCarContractData(int p_location_id, int p_car_id, ClsSqlDb clsSqlDb, ClsMySqlDb clsMySqlDb)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////
                // TRUNCATE TABLE
                // 専従先車両走行契約情報テーブルをクリア
                /////////////////////////////////////////////////////////////////////////
                sb.Clear();
                sb.AppendLine("DELETE FROM");
                sb.AppendLine("Mst_専従先車両走行契約情報");
                sb.AppendLine("WHERE");
                sb.AppendLine("location_id = " + p_location_id);
                sb.AppendLine("AND");
                sb.AppendLine("location_car_id = " + p_car_id);
                clsMySqlDb.DMLUpdate(sb.ToString());

                // SQL Server SELECT ALL
                // SQL Serverデータを読み込み、MySQLへ書き込む
                sb.Clear();
                sb.AppendLine("SELECT");
                sb.AppendLine(" id");
                sb.AppendLine(",location_id");
                sb.AppendLine(",location_car_id");
                sb.AppendLine(",unit_price");
                sb.AppendLine(",fuel_cost");
                sb.AppendLine(",contract_km");
                sb.AppendLine(",burden_fee");
                sb.AppendLine(",ins_user_id");
                sb.AppendLine(",ins_date");
                sb.AppendLine(",upd_user_id");
                sb.AppendLine(",upd_date");
                sb.AppendLine(",delete_flag");
                sb.AppendLine("FROM");
                sb.AppendLine("Mst_専従先車両走行契約情報");
                sb.AppendLine("WHERE");
                sb.AppendLine("location_id = " + p_location_id);
                sb.AppendLine("AND");
                sb.AppendLine("location_car_id = " + p_car_id);
                using (DataTable dt_val = clsSqlDb.DMLSelect(sb.ToString()))
                {
                    // MySQL INSERT
                    foreach (DataRow dr in dt_val.Rows)
                    {
                        sb.Clear();
                        sb.AppendLine("INSERT INTO Mst_専従先車両走行契約情報 (");
                        sb.AppendLine(" id");
                        sb.AppendLine(",location_id");
                        sb.AppendLine(",location_car_id");
                        sb.AppendLine(",unit_price");
                        sb.AppendLine(",fuel_cost");
                        sb.AppendLine(",contract_km");
                        sb.AppendLine(",burden_fee");
                        sb.AppendLine(",ins_user_id");
                        sb.AppendLine(",ins_date");
                        sb.AppendLine(",upd_user_id");
                        sb.AppendLine(",upd_date");
                        sb.AppendLine(",delete_flag");
                        sb.AppendLine(") VALUES (");
                        sb.AppendLine(dr["id"].ToString());
                        sb.AppendLine("," + dr["location_id"].ToString());
                        sb.AppendLine("," + dr["location_car_id"].ToString());
                        sb.AppendLine("," + dr["unit_price"].ToString());
                        sb.AppendLine("," + dr["fuel_cost"].ToString());
                        sb.AppendLine("," + dr["contract_km"].ToString());
                        sb.AppendLine("," + dr["burden_fee"].ToString());
                        if (dr.IsNull("ins_user_id") != true) { sb.AppendLine("," + dr["ins_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("ins_date") != true) { sb.AppendLine(",'" + dr["ins_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("upd_user_id") != true) { sb.AppendLine("," + dr["upd_user_id"].ToString()); }
                        else { sb.AppendLine(",0"); }
                        if (dr.IsNull("upd_date") != true) { sb.AppendLine(",'" + dr["upd_date"].ToString() + "'"); }
                        else { sb.AppendLine(",null"); }
                        if (dr.IsNull("delete_flag") != true) { sb.AppendLine("," + dr["delete_flag"].ToString()); }
                        else { sb.AppendLine("," + ClsPublic.FLAG_OFF); }
                        sb.AppendLine(")");
                        clsMySqlDb.DMLUpdate(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ClsLogger.Log(ex.Message);
                throw;
            }
        }
    }
}
