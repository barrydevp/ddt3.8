using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Logic
{
    public enum ePetEffectType
    {       
        AE,
        PE,
        CE,
        AE1036,
        E1039,
        E1122,
        E1123,
        E1124,
        E1125,
        E1126,
        E1127,
        E1133,
        E1134,
        E1138,
        E1139,
        E1149,
        E1418,
        E1419,
        E1420,
        E1421,
        E1422,
        E1423,
        E1424,
        E1425,
        AE1426,
        CE1426,
        AE1427,
        PE1428,
        PE1429,
        PE1430,
        PE1431,
        AE1432,
        CE1432,
        AE1433,
        CE1433,
        PE1435,
        AE1436,
        AE1437,
        E1438,
        AE2436,
        E2438,
        CE1287,
        AE1287,
        AE1280,
        AE1288,
        PE1278,
        PE1279,
        AE1281,
        AE1282,
        AE1283,
        PE1300,
        PE1301,
        CE1300,
        CE1301,
        PE1306,
        PE1307,
        AE1310,
        AE1311,
        CE1281,
        CE1282,
        CE1283,
        CE1310,
        CE1254,
        CE1255,
        CE1256,
        AE1254,
        AE1255,
        AE1256,
        AE1257,
        AE1258,
        AE1259,
        AE1260,
        CE1257,
        CE1258,
        CE1259,
        CE1260,
        AE1266,
        AE1267,
        AE1268,
        AE1269,
        PE1261,
        PE1262,
        PE1263,
        PE1264,
        PE1265,
        AE1222,
        CE1222,
        AE1270,
        AE1271,
        CE1270,
        CE1271,
        CE1266,
        PE1253,
        AE1238,
        AE1239,
        AE1240,
        AE1231,
        AE1248,
        AE1246,
        AE1249,
        AE1247,
        AE1250,
        AE1228,
        AE1229,
        AE1230,
        PE1241,
        PE1242,
        PE1235,
        PE1236,
        PE1237,
        AE1117,
        AE1243,
        AE1244,
        CE1238,
        CE1239,
        CE1240,
        CE1231,
        CE1248,
        CE1249,
        CE1250,
        CE1246,
        CE1247,
        PE1304,
        PE1305,
        CE1304,
        CE1305,
        CE1230,
        CE1228,
        CE1229,
        CE1235,
        CE1117,
        CE1243,
        CE1244,
        AE1201,
        AE1202,
        AE1203,
        CE1201,
        CE1202,
        CE1203,
        AE1204,
        AE1205,
        AE1206,
        AE1207,
        CE1204,
        CE1205,
        CE1206,
        CE1207,
        AE1208,
        AE1209,
        CE1208,
        CE1209,
        AE1210,
        AE1211,
        AE1212,
        AE1213,
        CE1210,
        CE1211,
        CE1212,
        CE1213,
        AE1224,
        AE1225,
        AE1226,
        AE1227,
        PE1214,
        PE1215,
        PE1216,
        PE1217,
        PE1218,
        PE1219,
        PE1223,
        AE1220,
        AE1221,
        CE1220,
        CE1221,
        AE1178,
        AE1179,
        AE1180,
        CE1178,
        CE1179,
        CE1180,
        AE1181,
        AE1182,
        AE1183,
        CE1181,
        CE1182,
        CE1183,
        AE1184,
        AE1185,
        AE1186,
        AE1187,
        CE1184,
        CE1185,
        CE1186,
        CE1187,
        PE1190,
        PE1191,
        PE1192,
        PE1193,
        PE1200,
        AE1194,
        AE1195,
        AE1196,
        AE1197,
        AE1198,
        AE1199,
        AE1038,
        CE1194,
        CE1195,
        CE1196,
        CE1197,
        CE1198,
        CE1199,
        CE1038,
        AE1189,
        AE1150,
        AE1151,
        AE1152,
        CE1150,
        CE1151,
        CE1152,
        AE1153,
        AE1154,
        AE1155,
        AE1156,
        CE1153,
        CE1154,
        CE1155,
        CE1156,
        AE1172,
        AE1173,
        AE1174,
        AE1175,
        CE1172,
        CE1173,
        CE1174,
        CE1175,
        PE1322,
        AE1170,
        AE1171,
        AE1176,
        AE1177,
        CE1170,
        CE1171,
        CE1176,
        CE1177,
        PE1163,
        PE1164,
        PE1165,
        PE1166,
        AE1161,
        AE1162,
        AE1323,
        AE1324,
        CE1161,
        CE1162,
        AE1358,
        AE1359,
        AE1360,
        CE1358,
        CE1359,
        CE1360,
        AE1361,
        AE1362,
        AE1363,
        CE1361,
        CE1362,
        CE1363,
        AE1364,
        AE1365,
        AE1366,
        AE1367,
        CE1366,
        CE1367,
        PE1368,
        PE1369,
        CE1368,
        CE1369,
        PE1372,
        PE1373,
        AE1374,
        AE1375,
        PE1376,
        AE1040,
        AE1041,
        AE1042,
        CE1040,
        CE1041,
        CE1042,
        AE1022,
        AE1023,
        AE1024,
        AE1025,
        CE1022,
        CE1023,
        CE1024,
        CE1025,
        AE1056,
        AE1057,
        PE1074,
        PE1075,
        PE1078,
        PE1079,
        AE1092,
        AE1093,
        AE1094,
        AE1095,
        AE1096,
        AE1097,
        AE1098,
        AE1099,
        AE1100,
        AE1101,
        CE1092,
        CE1093,
        CE1094,
        CE1095,
        CE1096,
        CE1097,
        CE1098,
        CE1099,
        CE1100,
        CE1101,
        PE1107,
        PE1110,
        PE1325,
        PE1326,
        PE1327,
        AE1439,
        AE1440,
        AE1441,
        CE1439,
        CE1440,
        CE1441,
        AE1442,
        AE1443,
        AE1444,
        AE1445,
        AE1446,
        CE1445,
        CE1446,
        AE1136,
        CE1136,
        AE1067,
        AE1068,
        CE1067,
        CE1068,
        PE1449,
        PE1450,
        PE1451,
        PE1452,
        PE1457,
        PE1459,
        PE1460,
        CE1459,
        CE1460,
        PE1137,
        AE1455,
        AE1456,
        CE1455,
        CE1456,
        E1328,
        E1329,
        E1330,
        AE1017,
        AE1021,
        AE1331,
        AE1332,
        AE1333,
        AE1334,
        AE1335,
        CE1017,
        CE1021,
        CE1331,
        CE1332,
        CE1333,
        CE1334,
        CE1335,
        AE1336,
        AE1337,
        CE1336,
        CE1337,
        AE1339,
        PE1340,
        PE1341,
        PE1351,
        PE1352,
        PE1355,
        PE1357,
        AE1082,
        AE1349,
        AE1350,
        AE1342,
        AE1343,
        AE1344,
        AE1345,
        AE1346,
        AE1347,

    }
}