0
data 3 4 5 6 7 8 9 10
104
add r1,r0,5
add r2,r0,1
add r2,r2,1
store (0),r2
load r3,(0)
branch r3,r1,120
halt