# TimeExctractor
Converting the time between two dates.
There are two public methods. First is "GetTime()" used for getting the actual time in system.DateTime standard.
Second method downloads three string arguments firts ("oldTime") stands for old time (time (as value) saved in past), 
the second argument is a nowTime (these two arguments downloads the time in System.DateTime standard, it means that You can push here directly System.DateTime).
Last IMPORTANT argument pulls information about in what type this method will return. 
This means, You enter ("Hours"/"Minutes"/"Seconds") and program will recalculate the time difference to that type.
AS DEFALUT this method TimeBetween(...) will return the value in Days.
