using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

string filePath = @"C:\Users\bdemm\Projects\NextAv\NextAv\docs\faa\aircraft.txt";

try
{
	StreamReader sr = new StreamReader(filePath);
    

	string line = sr.ReadLine();
	var makelist=new List<string>();


    while (line != null)
	{
		//insert into array if not already there

		string col = line.Split('\t')[3];
		makelist.Add(col);
       

        //Console.WriteLine(col);


		line = sr.ReadLine();
        
    }

    var newList = makelist.Distinct().ToList();
    newList.Sort();


    string newfilePath = @"C:\Users\bdemm\Projects\NextAv\NextAv\docs\faa\manufacturers.txt";
    StreamWriter sw = new StreamWriter(newfilePath); 
    
   
            

    //sort



    foreach (var item in newList)
    {
        if (item.Equals("SCBFLG"))
        {
            Console.WriteLine("here");
        }
        Console.WriteLine(item);
        
        sw.WriteLine(item);
    }
;
  
    sr.Close();
    sw.Close();
}
catch (Exception e)
{
	Console.WriteLine("Exception" + e.Message);
}
finally
{
	Console.WriteLine("Closing");
    



} 
