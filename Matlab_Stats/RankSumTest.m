clear all; % clear all variables
close all; % close all graphs
clc % clear command window
N = 30; % Number of records in each sample
Remove_outliers = 0; %1 to remove outliers
Ns = 2 %number of std
alpha = .05; %significance level
DataScript

Qlist = [];
Ilist = [];
for i = 5:5:100
    h = figure(i);
    xlabel('I (db)');
    ylabel('Q (db)');
    axis([0 35 0 35]);
   AllData =  Data(Data(:,1) ==i,:,:);
   Q = AllData(:,Q_COL);
   I = AllData(:,I_COL);
   Qavg = mean(Q(1:30)); 
   Qstd = std(Q);
      Iavg = mean(I);
    Istd = std(I);
%    fprintf(' %g Distance Q(avg,std) = (%g,%g)\n',...
%         i,Qavg,Qstd)
%      fprintf(' %g Distance I(avg,std) = (%g,%g)\n',...
%         i,Iavg,Istd)
   length = size(Q);
   
    
    for j = 1:30:length
        if(j+N < length(1))
            Qsample = Q(j:j+N);
        else
            Qsample = Q(j:end);
        end
        if(j+N < length(1))
            Isample = I(j:j+N);
        else
            Isample = I(j:end);
        end
        Qsavg = mean(Qsample);
        Qsstd = std(Qsample);
        
        Isavg = mean(Isample);
        Isstd = std(Isample);
        if(Isstd == 0)
            Isstd = .01;
        end
        if(Qsstd == 0)
            Qsstd = .01;
        end
        hQ = ranksum(Qsample,Q(1:30));
        hI = ranksum(Isample,I(1:30));
        
        fprintf('%g,%g,%g\n',i,hI,hQ);
        if(hQ == 1 && hI == 1)
            color = 'g';
        else if(hQ == 0 && hI == 0)
                color = 'k';
            else
                color = 'blue';
            end  
        end
      
        plot(hI,hQ,[color '.'],'MarkerSize',20);
        hold on;
    end
   

    saveas(h,sprintf('%g_Rank_Sum_Data_%g',i,N),'jpg') 
end
% plot(Ilist,Qlist);
% hold on;