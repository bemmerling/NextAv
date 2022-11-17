using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

internal class Program
{
    private static void Main(string[] args)
    {

        //ReplaceMakewithID();


        string filePath = @"C:\Users\bdemm\Projects\NextAv\NextAv\docs\acftImport.csv";

        try
        {
            StreamReader sr = new StreamReader(filePath);


            string line = sr.ReadLine();
            line = sr.ReadLine();//skipping headers

            // string newfilePath = @"C:\Users\bdemm\Projects\NextAv\NextAv\docs\acftImport.csv";
            // StreamWriter sw = new StreamWriter(newfilePath);

            string m_ConnectionString =
                    @"Server = tcp:takeoff.database.windows.net,1433; Initial Catalog = NextAvDev;" +
                    "Persist Security Info=False; User ID = llamataste; Password =fpm123Skull; MultipleActiveResultSets = False; Encrypt = True;" +
                    "TrustServerCertificate = False; Connection Timeout = 30";

            SqlConnection DbConnection = new SqlConnection(m_ConnectionString);
            DbConnection.Open();
            Console.WriteLine("Succesfully Connected");

            while (line != null)
            {
                string[] acft = line.Split(',');

                string sqlCommand = 
                    String.Format("INSERT INTO AIRCRAFT VALUES ( {0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13})",
                    acft[0], acft[1], acft[2], acft[3], acft[4], acft[5], acft[6], acft[7], acft[8], acft[9], acft[10], acft[11], acft[12], acft[13] );
                Console.WriteLine(sqlCommand);
                SqlCommand cmd = new SqlCommand(sqlCommand, DbConnection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                line = sr.ReadLine();

            }

            



            //foreach (var item in newList)
            //{

            //    string sqlCommand = String.Format("INSERT INTO MANUFACTURER VALUES (  '{0}', '', '' )", item);
            //    SqlCommand cmd = new SqlCommand(sqlCommand, DbConnection);
            //    cmd.ExecuteNonQuery();
            //    cmd.Dispose();

            //}


            //SqlDataAdapter adapter = new SqlDataAdapter();

            sr.Close();
            //sw.Close();
            DbConnection.Close();


        }
        catch (Exception e)
        {
            Console.WriteLine("Exception" + e.Message);
        }
        finally
        {
            Console.WriteLine("Closing");
        }
    }

    // static void ReplaceMakewithID()
    // {
    //     string filePath = @"C:\Users\bdemm\Projects\NextAv\NextAv\docs\faa\aircraft.txt";
    //     string newFilePath = @"C:\Users\bdemm\Projects\NextAv\NextAv\docs\faa\trfmdAircraft.txt";

    //     try
    //     {
    //         StreamReader sr = new StreamReader(filePath);


    //         string line = sr.ReadLine();
    //         var makelist = new List<string>();


    //         //while (line != null)
    //         //{
    //         //    //insert into array if not already there

    //         //    string col = line.Split('\t');
    //         //    makelist.Add(col);


    //         //    //Console.WriteLine(col);


    //         //    line = sr.ReadLine();

    //         //}
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine("Exception" + e.Message);
    //     }
    //     finally
    //     {

    //     }
    // }
}

// class Aircraft
// {

//         int manufacturer;
//         string model;
//         int yearmin;
//         int yearmax;
//         int crew;
//         int pax;
//         int airworthiness;
//         int gearType;
//         int enginecount;
//         int opc;
//         int riskGroup;
//         float hullmod;
//         float liabilityMod;
//         int underwriterLevel;

// }