clear all; % clear all variables
close all; % close all graphs
clc % clear command window
N = 25; % Number of records in each sample
Remove_outliers = 0; %1 to remove outliers
Ns = 2; %number of std
alpha = .05; %significance level
DataScript

Qlist = [];
Ilist = [];
for i = 5:5:100
%     h = figure(i);
%     xlabel('I (db)');
%     ylabel('Q (db)');
%     axis([0 35 0 35]);
   AllData =  Data(Data(:,1) ==i,:,:);
   NotData = Data(Data(:,1) ~=i,:,:);
   NotQ =  NotData(:,Q_COL);
   NotI =  NotData(:,I_COL);
   Q = AllData(:,Q_COL);
   I = AllData(:,I_COL);
   Qavg = mean(Q); 
   Qstd = std(Q);
   Iavg = mean(I);
   Istd = std(I);
    
%     fprintf('I Distance: %g Kolmogorov-Smirnov test:%g\n',i,kstest(I))
%     fprintf('Q Distance: %g Kolmogorov-Smirnov test:%g\n',i,kstest(Q))
   length = size(NotQ);
   
    
    for j = 1:N:length
        fprintf('Checking on %g sample on configuration on %g\n',i,NotData(j,1));
        if(j+N < length(1))
            Qsample = NotQ(j:j+N);
        else
            Qsample = NotQ(j:end);
        end
        if(j+N < length(1))
            Isample = NotI(j:j+N);
        else
            Isample = NotI(j:end);
        end
        [pQ,hQ] = ranksum(Qsample,Q(1:N));
        [pI,hI] = ranksum(Isample,I(1:N));
        Qlist = [Qlist hQ];
        Ilist = [Ilist hI];
%         fprintf('Distance %g, Q Series: %g Rank Sum:%g\n',i,j,pQ)
%         fprintf('Distance %g, I Series: %g Rank Sum:%g\n',i,j,pI)
       
    end
    
    
 
end
figure(1);
hist(Qlist,60);

figure(2);
hist(Ilist,60);
