clear all; % clear all variables
close all; % close all graphs
clc % clear command window
N = 1; % Number of standard deviations on eather side of avg
Remove_outliers = 1; %1 to remove outliers

DataScript
figure(1)
xlabel('I (db)');
ylabel('Q (db)');
axis([0 35 0 35]);
for i = 5:5:100
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


        I = I(I>(Iavg - Istd) & I<(Iavg + Istd));
        Iavg = mean(I);
        Istd = std(I);
        if(Istd == 0)
            Istd = .005;
        end
        if(Qstd == 0)
            Qstd = .005;
        end
    end
    
    
    rectangle('Position',[Iavg-N*Istd,Qavg-N*Qstd,N*2*Istd,N*2*Qstd],'Curvature',[1,1])
    plot(Iavg,Qavg,'r.','MarkerSize',5);
    hold on;
    
    fprintf(' %g Distance Q(avg,std) = (%g,%g) I(avg,std) = (%g,%g)\n',...
        i,Qavg,Qstd,Iavg,Istd)
    
end
