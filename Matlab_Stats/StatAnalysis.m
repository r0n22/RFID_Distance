clear all; % clear all variables
close all; % close all graphs
clc % clear command window
N = 1; % Number of standard deviations on eather side of avg
Remove_outliers = 0; %1 to remove outliers

DataScript
figure(1)
xlabel('I (db)');
ylabel('Q (db)');
axis([0 35 0 35]);
Qlist = [];
Ilist = [];
for i = 10:10:100
   Q = [];
   I = [];
   
    for j = 1:10531
      if(Data(j,1) == i)
         Q = [Q Data(j,Q_COL)];
         I = [I Data(j,I_COL)];
         
      end
    end
    
    Qavg = mean(Q); 
    Qstd = std(Q);
    
    
    Iavg = mean(I);
    Istd = std(I);
    
    %pull out outliers
    if(Remove_outliers == 1)
        Q = Q(Q>(Qavg - Qstd) & Q<(Qavg + Qstd));
        Qavg = mean(Q);
        Qstd = std(Q);
        Qirq = iqr(Q);
        Qmedian = median(Q);
        I = I(I>(Iavg - Istd) & I<(Iavg + Istd));
        Iavg = mean(I);
        Istd = std(I);
        Iirq = iqr(I);
        Imedian = median(I);
        if(Istd == 0)
            Istd = .005;
        end
        if(Qstd == 0)
            Qstd = .005;
        end
    end
    
    
    rectangle('Position',[Iavg-N*Istd,Qavg-N*Qstd,N*2*Istd,N*2*Qstd],'Curvature',[1,1])
    hold on;
    plot(Iavg,Qavg,'r.','MarkerSize',20);
    hold on;
    
    Qlist = [Qlist Qavg];
    Ilist = [Ilist Iavg];
    
    fprintf(' %g Distance Q(avg,std) = (%g,%g) I(avg,std) = (%g,%g)\n',...
        i,Qavg,Qstd,Iavg,Istd)

end
plot(Ilist,Qlist);
hold on;