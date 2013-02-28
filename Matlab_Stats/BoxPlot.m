clear all; % clear all variables
close all; % close all graphs
clc % clear command window
DataScript
figure(1)
boxplot(Data(:,Q_COL),Data(:,1))
title('Box Plot for Q');
xlabel('Distance');
%boxplot(IData);
figure(2)
boxplot(Data(:,I_COL),Data(:,1))
title('Box Plot for I');
xlabel('Distance');