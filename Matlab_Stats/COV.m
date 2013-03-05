clear all; % clear all variables
close all; % close all graphs
clc % clear command window
N = 75;

DataScript

for i = 15:15
    h = figure(i);
    xlabel('I (db)');
    ylabel('Q (db)');
    axis([0 35 0 35]);
    AllData =  Data(Data(:,1) ==i,:,:);
    Q = AllData(:,Q_COL);
    I = AllData(:,I_COL);

    TestCov = [Q(1:100) I(1:100)];

    X = cov(TestCov);

    [Udata,Sdata,Vdata] = svd(X);
    
    fprintf('S Matrix Distance %g:\n',i);
    fprintf('%g\t',diag(Sdata));
    fprintf('\n');
    plot(Sdata(1,1),Sdata(2,2),'r.','MarkerSize',20);
    
    hold on;
    length = size(Q);
    
     for j = 100:N:length(1)
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
        TestCov = [Qsample Isample];
        
         X = cov(TestCov);
        [U,S,V] = svd(X);
%         if(any(S-Sdata))
        fprintf('\n',i);
        fprintf('%g\t',diag(S-Sdata));
        fprintf('\n');
        plot(S(1,1),S(2,2),'g.','MarkerSize',20);
        hold on;
%         end
    end

end