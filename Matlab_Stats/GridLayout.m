clear all; % clear all variables
close all; % close all graphs
clc % clear command window
A = [50 -50]
B = [-50 50]
figure
axis([0 100 0 100]);
rectangle('Position',[0,0,100,100],'EdgeColor','k')
hold on;
plot(A(1),A(2),'red.','MarkerSize',20);
hold on;
plot(B(1),B(2),'blue.','MarkerSize',20);
hold on;
for i = 5:5:150
rectangle('Position',[A(1)-i,A(2)-i,2*i,2*i],'Curvature',[1,1],'EdgeColor','red')
rectangle('Position',[B(1)-i,B(2)-i,2*i,2*i],'Curvature',[1,1],'EdgeColor','blue')

hold on;
end