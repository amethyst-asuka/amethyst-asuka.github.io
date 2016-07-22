REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @7/22/2016 8:07:13 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Storage.MySql

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `neural_tokens`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `neural_tokens` (
'''   `uid` int(11) NOT NULL,
'''   `t1` int(11) NOT NULL,
'''   `t2` int(11) NOT NULL,
'''   `t3` int(11) NOT NULL,
'''   `t4` int(11) NOT NULL,
'''   `t5` int(11) NOT NULL,
'''   `key` int(11) NOT NULL,
'''   PRIMARY KEY (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping data for table `neural_tokens`
''' --
''' 
''' LOCK TABLES `neural_tokens` WRITE;
''' /*!40000 ALTER TABLE `neural_tokens` DISABLE KEYS */;
''' /*!40000 ALTER TABLE `neural_tokens` ENABLE KEYS */;
''' UNLOCK TABLES;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("neural_tokens", Database:="authorization_token")>
Public Class neural_tokens: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property uid As Long
    <DatabaseField("t1"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property t1 As Long
    <DatabaseField("t2"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property t2 As Long
    <DatabaseField("t3"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property t3 As Long
    <DatabaseField("t4"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property t4 As Long
    <DatabaseField("t5"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property t5 As Long
    <DatabaseField("key"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property key As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `neural_tokens` (`uid`, `t1`, `t2`, `t3`, `t4`, `t5`, `key`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `neural_tokens` (`uid`, `t1`, `t2`, `t3`, `t4`, `t5`, `key`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `neural_tokens` WHERE `uid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `neural_tokens` SET `uid`='{0}', `t1`='{1}', `t2`='{2}', `t3`='{3}', `t4`='{4}', `t5`='{5}', `key`='{6}' WHERE `uid` = '{7}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, t1, t2, t3, t4, t5, key)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, t1, t2, t3, t4, t5, key)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, t1, t2, t3, t4, t5, key, uid)
    End Function
#End Region
End Class


End Namespace
