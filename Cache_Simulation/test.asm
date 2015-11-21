104
add r1,r0,10
load r2,r0(250)
load r3,r0(500)
add r3,r2,r3
store r0(1000),r3
add r0,r0,1
branch r0,r1,112
halt
250
data 1 1 1 1 1 1 1 1
data 2 2 2 2 2 2 2 2
data 3 3 3 3 3 3 3 3
data 4 4 4 4 4 4 4 4
data 5 5 5 5 5 5 5 5
data 6 6 6 6 6 6 6 6
data 7 7 7 7 7 7 7 7
data 8 8 8 8 8 8 8 8
data 9 9 9 9 9 9 9 9
data 10 10 10 10 10 10 10 10
500
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
data 1 2 3 4 5 6 7 8
1000
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0
data 0 0 0 0 0 0 0 0