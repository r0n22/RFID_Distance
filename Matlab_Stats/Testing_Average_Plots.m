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
   Qavg = mean(Q); 
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
        hI = ranksum(Qsample,Q,alpha);
        hQ = ranksum(Isample,I,alpha);
        
        fprintf('%g,%g,%g\n',i,hI,hQ);
        if(hQ == 1 && hI == 1)
            color = 'g';
        else if(hQ == 0 && hI == 0)
                color = 'k';
            else
                color = 'blue';
            end  
        end
        rectangle('Position',[Isavg-Ns*Isstd,Qsavg-Ns*Qsstd,Ns*2*Isstd,Ns*2*Qsstd],'EdgeColor',color,'Curvature',[1,1])
        hold on;
        plot(Isavg,Qsavg,[color '.'],'MarkerSize',20);
        hold on;
    end
    rectangle('Position',[Iavg-Ns*Istd,Qavg-Ns*Qstd,Ns*2*Istd,Ns*2*Qstd],'EdgeColor','r','Curvature',[1,1])
    hold on;
    plot(Iavg,Qavg,'r.','MarkerSize',20);
    hold on;
%     Qavg = mean(Q); 
%     Qstd = std(Q);
%     
%     
%     Iavg = mean(I);
%     Istd = std(I);
%     
%     %pull out outliers
%     if(Remove_outliers == 1)
%         Q = Q(Q>(Qavg - Qstd) & Q<(Qavg + Qstd));
%         Qavg = mean(Q);
%         Qstd = std(Q);
%         Qirq = iqr(Q);
%         Qmedian = median(Q);
%         I = I(I>(Iavg - Istd) & I<(Iavg + Istd));
%         Iavg = mean(I);
%         Istd = std(I);
%         Iirq = iqr(I);
%         Imedian = median(I);
%         if(Istd == 0)
%             Istd = .005;
%         end
%         if(Qstd == 0)
%             Qstd = .005;
%         end
%     end
%     
%     
%     rectangle('Position',[Iavg-N*Istd,Qavg-N*Qstd,N*2*Istd,N*2*Qstd],'Curvature',[1,1])
%     hold on;
%     plot(Iavg,Qavg,'r.','MarkerSize',20);
%     hold on;
%     
%     Qlist = [Qlist Qavg];
%     Ilist = [Ilist Iavg];
%     
%     fprintf(' %g Distance Q(avg,std) = (%g,%g) I(avg,std) = (%g,%g)\n',...
%         i,Qavg,Qstd,Iavg,Istd)
    saveas(h,sprintf('%g_Sample_Data_%g',i,N),'jpg') 
end
% plot(Ilist,Qlist);
% hold on;