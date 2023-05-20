using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace BL
{
    public class Usuario
    {
        //STORE PROCEDURE SQLCLIENT

        //public static ML.Result Add(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL_SQLClient.Conexion.GetConnection()))
        //        {
        //            var query = "UsuarioAdd";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = context;
        //                cmd.CommandText = query;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] collection = new SqlParameter[5];

        //                collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
        //                collection[0].Value = usuario.Nombre;

        //                collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
        //                collection[1].Value = usuario.ApellidoPaterno;

        //                collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
        //                collection[2].Value = usuario.ApellidoMaterno;

        //                collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
        //                collection[3].Value = usuario.FechaNacimiento;

        //                collection[4] = new SqlParameter("IdRol", SqlDbType.Int);
        //                collection[4].Value = usuario.Rol.IdRol;

        //                cmd.Parameters.AddRange(collection);
        //                cmd.Connection.Open();

        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Exception = ex;
        //    }
        //    return result;
        //}

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQLClient.Conexion.GetConnection()))
                {
                    var query = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("IdRol", SqlDbType.Int);
                        collection[5].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQLClient.Conexion.GetConnection()))
                {
                    var query = "UsuarioDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQLClient.Conexion.GetConnection()))
                {
                    var query = "UsuarioGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = (int)row[0];
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = (int)row[5];
                                usuario.Rol.NombreRol = row[6].ToString();

                                result.Objects.Add(usuario);
                            }
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
            }

            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQLClient.Conexion.GetConnection()))
                {
                    var query = "UsuarioGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.Add(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            DataRow row = usuarioTable.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = (int)row[0];
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Rol.IdRol = (int)row[5];
                            usuario.Rol.NombreRol = row[6].ToString();

                            result.Object = usuario;
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
            }
            return result;
        }

        //MYSQL

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (MySqlConnection context = new MySqlConnection(DL_MySQL.Conexio.ConnectionString()))
                {
                    var query = "INSERT INTO `Usuario" +
                        "`(`IdUsuario`" +
                        ", `Nombre`" +
                        ", `ApellidoPaterno`" +
                        ", `ApellidoMaterno`" +
                        ", `FechaNacimiento`" +
                        ", `IdRol`) " +
                        "VALUES" +
                        "('@IdUsuario'" +
                        ", '@Nombre'" +
                        ", '@ApellidoPaterno'" +
                        ", '@ApellidoMaterno'" +
                        ", '@FechaNacimiento'" +
                        ", '@IdRol')";


                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        MySqlParameter[] collection = new MySqlParameter[6];

                        collection[0] = new MySqlParameter("IdUsuario", MySqlDbType.Int32);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new MySqlParameter("Nombre", MySqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new MySqlParameter("ApellidoPaterno", MySqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new MySqlParameter("ApellidoMaterno", MySqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new MySqlParameter("FechaNacimiento", MySqlDbType.Date);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new MySqlParameter("IdRol", MySqlDbType.Int32);
                        collection[5].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
            }
            return result;
        }
    }
}