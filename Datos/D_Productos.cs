﻿using ProcesoCRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class D_Productos
    {
        public DataTable Listado_pr(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string Guardar_pr(int nOpcion,
                                E_Productos oPro
                                )
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GUARDAR_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nCodigo_pr", SqlDbType.Int).Value = oPro.Codigo_pr;
                Comando.Parameters.Add("@cDescripcion_pr", SqlDbType.VarChar).Value = oPro.Descripcion_pr;
                Comando.Parameters.Add("@cMarca_pr", SqlDbType.VarChar).Value = oPro.Marca_pr;
                Comando.Parameters.Add("@nCodigo_me", SqlDbType.Int).Value = oPro.Codigo_me;
                Comando.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = oPro.Codigo_ca;
                Comando.Parameters.Add("@nStock_actual", SqlDbType.Decimal).Value = oPro.Stock_actual;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo realizar la operación";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;
        }

        public string Activo_pr(int nCodigo_pr, bool bEstado_activo)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ACTIVO_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_pr", SqlDbType.Int).Value = nCodigo_pr;
                Comando.Parameters.Add("@bEstado_activo", SqlDbType.Bit).Value = bEstado_activo;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo realizar la operación";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Respuesta;
        }
        public DataTable Listado_me()
        {
            SqlDataReader Resultado;
            DataTable Table = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_ME", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                if (Resultado != null)
                {
                    Table.Load(Resultado);
                }
                else
                {
                    Table = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            return Table;
        }

        public DataTable Listado_ca()
        {
            SqlDataReader Resultado;
            DataTable Table = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_CA", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                if (Resultado != null)
                {
                    Table.Load(Resultado);
                }
                else
                {
                    Table = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Table;
        }
    }
}
