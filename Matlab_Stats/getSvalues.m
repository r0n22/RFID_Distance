  clc;
  clear;
Sall=zeros(100/5,3,3);
S1=zeros(4,100/5);
S2=zeros(4,100/5);
DataScript;
for j=1:4
    switch j
        case 1
            Data=importdata('HomeData1.mat');
        case 2
            Data=importdata('HomeData2.mat');
        case 3
            Data=importdata('HomeData3.mat');
        case 4
            Data=importdata('HomeData4.mat');
        otherwise
    end
    for i=5:5:100
        AllData =  Data(Data(:,1) ==i,:,:);
        covar=cov(AllData);

        [U,S,V]=svd(covar);
        S1(j,i/5)=S(1,1);
        S2(j,i/5)=S(2,2);
    end
    
end

subplot(2,1,1); 
hold all
scatter(5:5:100,S1(1,:))
scatter(5:5:100,S1(2,:))
scatter(5:5:100,S1(3,:))
scatter(5:5:100,S1(4,:))
title('S1')
hold off

subplot(2,1,2);
hold all
scatter(5:5:100,S2(1,:))
scatter(5:5:100,S2(2,:))
scatter(5:5:100,S2(3,:))
scatter(5:5:100,S2(4,:))
title('S2');
hold off
