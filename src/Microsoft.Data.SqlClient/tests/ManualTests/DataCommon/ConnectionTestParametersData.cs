﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TDS.PreLogin;

namespace Microsoft.Data.SqlClient.ManualTesting.Tests.DataCommon
{
    public class ConnectionTestParametersData
    {
        private static readonly string s_fullPathToCer = Path.Combine(Directory.GetCurrentDirectory(), "localhostcert.cer");
        private static string s_hostName = System.Net.Dns.GetHostName();

        public static ConnectionTestParametersData Data { get; } = new ConnectionTestParametersData();
        public List<ConnectionTestParameters> ConnectionTestParametersList { get; set; }

        public static IEnumerable<object[]> GetConnectionTestParameters()
        {
            yield return new object[] { Data.ConnectionTestParametersList[0] };
            yield return new object[] { Data.ConnectionTestParametersList[1] };
            yield return new object[] { Data.ConnectionTestParametersList[2] };
            yield return new object[] { Data.ConnectionTestParametersList[3] };
            yield return new object[] { Data.ConnectionTestParametersList[4] };
            yield return new object[] { Data.ConnectionTestParametersList[5] };
            yield return new object[] { Data.ConnectionTestParametersList[6] };
            yield return new object[] { Data.ConnectionTestParametersList[7] };
            yield return new object[] { Data.ConnectionTestParametersList[8] };
            yield return new object[] { Data.ConnectionTestParametersList[9] };
            yield return new object[] { Data.ConnectionTestParametersList[10] };
            yield return new object[] { Data.ConnectionTestParametersList[11] };
            yield return new object[] { Data.ConnectionTestParametersList[12] };
            yield return new object[] { Data.ConnectionTestParametersList[13] };
            yield return new object[] { Data.ConnectionTestParametersList[14] };
            yield return new object[] { Data.ConnectionTestParametersList[15] };
        }

        public ConnectionTestParametersData() 
        {
            ConnectionTestParametersList = new List<ConnectionTestParameters>
            {
                // First batch with TdsEncryptionType = Off
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Optional,
                    TrustServerCertificate = false,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = false,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Optional,
                    TrustServerCertificate = true,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = true,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = false,
                    Certificate = s_fullPathToCer,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = true,
                    Certificate = s_fullPathToCer,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = false,
                    Certificate = null,
                    HostNameInCertificate = s_hostName,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.Off,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = true,
                    Certificate = null,
                    HostNameInCertificate = s_hostName,
                    TestResult = true
                },
                // Second batch with TdsEncryptionType = On
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Optional,
                    TrustServerCertificate = false,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = false,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Optional,
                    TrustServerCertificate = true,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = true,
                    Certificate = null,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = false,
                    Certificate = s_fullPathToCer,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = true,
                    Certificate = s_fullPathToCer,
                    HostNameInCertificate = null,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = false,
                    Certificate = null,
                    HostNameInCertificate = s_hostName,
                    TestResult = true
                },
                new ConnectionTestParameters
                {
                    TdsEncryptionType = TDSPreLoginTokenEncryptionType.On,
                    Encrypt = SqlConnectionEncryptOption.Mandatory,
                    TrustServerCertificate = true,
                    Certificate = null,
                    HostNameInCertificate = s_hostName,
                    TestResult = true
                },
            };
        }
    }
}