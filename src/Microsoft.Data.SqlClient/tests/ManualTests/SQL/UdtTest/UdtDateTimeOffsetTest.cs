﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Data;
using Microsoft.Data.SqlClient.ManualTesting.Tests.DataCommon;
using Xunit;

namespace Microsoft.Data.SqlClient.ManualTesting.Tests.SQL.UdtTest
{
    public class UdtDateTimeOffsetTest
    {
        private readonly string _connectionString = null;
        private readonly string _udtTableType = DataTestUtility.GetUniqueName("DataTimeOffsetTableType");

        public UdtDateTimeOffsetTest()
        {
            _connectionString = DataTestUtility.TCPConnectionString;
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer), nameof(DataTestUtility.IsNotAzureSynapse))]
        public void SelectFromSqlParameterShouldSucceed()
        {
            using (SqlConnection connection = SetupUserDefinedTableType(_connectionString, _udtTableType))
            {
                try
                {
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(2024, 1, 1, 12, 34, 56, TimeSpan.Zero);
                    var param = new SqlParameter
                    {
                        ParameterName = "@params",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = $"dbo.{_udtTableType}",
                        Value = new DateTimeOffsetList[] { new DateTimeOffsetList(dateTimeOffset) }
                    };

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM @params";
                        cmd.Parameters.Add(param);
                        var result = cmd.ExecuteScalar();
                        Assert.Equal(dateTimeOffset, result);
                    }
                }
                finally
                {
                    DataTestUtility.DropUserDefinedType(connection, _udtTableType);
                }
            }
        }

        private static SqlConnection SetupUserDefinedTableType(string connectionString, string tableTypeName)
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"CREATE TYPE {tableTypeName} AS TABLE ([Value] DATETIMEOFFSET(1) NOT NULL) ";
                cmd.ExecuteNonQuery();
            }
            return connection;
        }
    }
}