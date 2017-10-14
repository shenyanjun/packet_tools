using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace clean_env {

    class Program {
        static void Main(string[] args) {
            createMySqlEnv();
        }
        //创建sql数据表格
        static void createMySqlEnv() {
            MySqlConnection _db_conn = new MySqlConnection("Database=packets;Data Source=localhost;User Id=root;Password=root;pooling=false;CharSet=utf8;Port=3306;allow zero datetime=true");
            _db_conn.Open();
            string rm_table = "DROP DATABASE IF EXISTS packets; CREATE DATABASE IF NOT EXISTS packets default character set utf8 COLLATE utf8_general_ci; ";
            MySqlCommand cmd = new MySqlCommand(rm_table, _db_conn);
            cmd.ExecuteNonQuery();

            string create_database = "CREATE DATABASE IF NOT EXISTS packets default character set utf8 COLLATE utf8_general_ci;";
            cmd.CommandText = create_database;
            cmd.ExecuteNonQuery();
            string exe_sql = "CREATE TABLE IF Not Exists  `box_set`( " +
                                     "`snbox_serialnum` varchar(100) NOT NULL, " +
                                     "`snbox_num` int(10) NOT NULL, " +
                                     "`snbox_box` varchar(100) NOT NULL, " +
                                     "`snbox_product` varchar(100) NOT NULL, " +
                                     "`snbox_curboxnum` varchar(100) NOT NULL DEFAULT 0, " +
                                     "`snbox_numbox` varchar(100) NOT NULL," +
                                     " PRIMARY KEY (`snbox_serialnum`), " +
                                     " UNIQUE KEY `snbox_serialnum` (`snbox_serialnum`) USING BTREE " +
                                     ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            exe_sql = "CREATE TABLE IF  Not EXISTS `admin` (" +
                                    "`persno` varchar(8) CHARACTER SET ascii DEFAULT NULL, " +
                                    "UNIQUE KEY `persno` (`persno`) USING BTREE " +
                                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            exe_sql = "CREATE TABLE IF  Not EXISTS `root`( " +
                            "`super_user` varchar(10) NOT NULL, " +
                            "`pass_word` varchar(10) NOT NULL, " +
                            "PRIMARY KEY (`super_user`) " +
                            ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            exe_sql = "INSERT INTO `root` VALUES ('admin', 'admin');";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            exe_sql = "INSERT INTO admin set  persno = '1';";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            _db_conn.Close();
        }
    }
}
