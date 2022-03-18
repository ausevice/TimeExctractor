
public static class TimeExctractor 
{
    ///<summary> Converting the time between two dates (how much time has passed since (oldTime)) </summary>
    public static string GetTime()
    {   
        string Time = System.DateTime.Now.ToString();
        return Time;
    }   
    public static long TimeBetween(string oldTime, string nowTime, string dType)
    {   
        string _oldTime = oldTime;
        long dYears = TimeExtruder( nowTime , "Year" ) - TimeExtruder( oldTime , "Year" );
        //Add some protection for time travelers, to prevent to back in time   if( dYears < 0) {Debug.LogError("TimeExctractor :: TimeBetween the date is not vaild, check a date and Try again, (years difference is below ZERO!)"); return null; }
        long dMonth = TimeExtruder( nowTime , "Month" ) - TimeExtruder( oldTime , "Month" );
        long dDay = TimeExtruder( nowTime , "Day" ) - TimeExtruder( oldTime , "Day" );
        long dHours = TimeExtruder( nowTime , "Hours" ) - TimeExtruder( oldTime , "Hours" );
        long dMinutes = TimeExtruder( nowTime , "Minutes" ) - TimeExtruder( oldTime , "Minutes" );
        long dSeconds = TimeExtruder( nowTime , "Seconds" ) - TimeExtruder( oldTime , "Seconds" );

        // *** Years to months ***
        long outValue = dYears * 12;

        // *** Adding months difference ***
        outValue = outValue + dMonth; //in Months
        
        // *** Calculating value to days ***
        outValue = MonthsToDays(_oldTime, outValue) + dDay;
        // *** Calcualting value to  ***

        if(dType == "Seconds") outValue = ( 24 * outValue ) * 60 * 60 + ( dHours * 60 * 60 ) + ( dMinutes * 60 ) + dSeconds;
        if(dType == "Minutes") outValue = ( 24 * outValue ) * 60 + ( dHours * 60 ) + dMinutes ;
        if(dType == "Hours") outValue = ( 24 * outValue ) + dHours;

        return outValue;
    }
    private static long MonthsToDays(string startTime, long monthDif)
    {   
        long Days = 0;
        long startYear = TimeExtruder( startTime , "Year");
        long startMonth = TimeExtruder( startTime , "Month");
        
        long toEndOfYear = 12 - startMonth;
        long _monthDif = monthDif;
        
        if(toEndOfYear >= monthDif)
        {
            for(int i = 1; i <= monthDif; i++)
            {
                Days += System.DateTime.DaysInMonth((int)startYear, (int)startMonth + i);
            }
            return Days;
        }
        else if( toEndOfYear < monthDif )
        {   
            long _oMonths = 0;
            //*** Days to end of year ***
            for(int i = 1; i <= toEndOfYear; i++)
            {
                Days += System.DateTime.DaysInMonth((int)startYear, (int)startMonth + i);
            }
            long oMonths = monthDif - toEndOfYear;
            //*** Looking for full years 
            if( oMonths / 12 >= 1 )
            {
                _oMonths = oMonths % 12;
                for(long i = (oMonths - _oMonths ) / 12; 0 < i ; i--)
                {   

                    if(System.DateTime.IsLeapYear((int)startYear + (int)i) )
                    {
                        Days += 366;
                    }
                    else
                    {
                        Days += 365;
                    }
                }
                for(long i = 1; i <= _oMonths; i++)
                {
                    Days += System.DateTime.DaysInMonth((int)startYear + (int)(oMonths - _oMonths ) / 12, (int)i);
                }
            }
            else
            {
                for(long i = 1; i <= oMonths; i++)
                {
                    Days += System.DateTime.DaysInMonth((int)startYear + (int)(oMonths - _oMonths ) / 12, (int)i);
                }
            }
        }
 
        return Days;
    }
    private static long TimeExtruder(string Time, string dType)
    {   
        long timeValue = 0;
        switch ( dType )
        {
            case "Day" : 
                timeValue =  ( (Time[0] - '0') * 10 ) + Time[1] - '0'; //Day
                break;

            case "Month" :
                timeValue =   ( (Time[3] - '0') * 10 ) + Time[4] - '0'; //Month
                break;

            case "Year" :
                timeValue =   ( (Time[6] - '0') * 1000 ) + ( (Time[7] - '0') * 100 ) + ( (Time[8] - '0') * 10 ) + Time[9] - '0'; //Year
                break;

            case "Hours" :
                timeValue =  ( (Time[11] - '0') * 10 ) + Time[12] - '0'; //Hours
                break;

            case "Minutes" :
                timeValue =   ( (Time[14] - '0') * 10 ) + Time[15] - '0'; //Minutes 
                break;

            case "Seconds" :
                timeValue =   ( (Time[17] - '0') * 10 ) + Time[18] - '0'; //Seconds
                break;
        }

        return timeValue;
    }
    
}
