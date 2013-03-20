clear all; % clear all variables
close all; % close all graphs
clc % clear command window
N = 64; % Number of records in each sample
Remove_outliers = 0; %1 to remove outliers
FFTCoe = 5;
alpha = .05; %significance level
length = 30;
DataScript
cc=hsv(50);
Qlist = [];
Ilist = [];

for i = 5:5:100
   
   
   AllData =  Data(Data(:,1) ==i,:,:);
   Q = AllData(:,Q_COL);
   I = AllData(:,I_COL);

   Correct_Count = 0;
   Count = 0;
    
   
        
    NFFT = 2^nextpow2(size(Q,1)); % Next power of 2 from length of y
    Qfft = fft(Q,NFFT)/size(Q,1);
    Ifft = fft(I,NFFT)/size(I,1);
    %F = 1000/2*linspace(0,1,NFFT/2+1);

    % Plot single-sided amplitude spectrum.
%    
    %build Lookup Table
    QLookup(i,:)=2*abs(Qfft(1:FFTCoe));
    ILookup(i,:)=2*abs(Ifft(1:FFTCoe));
    QPower =0;
    IPower =0;
    for fd = 1:1:FFTCoe
        QPower =QPower + QLookup(i,fd)^2;
        IPower = IPower + QLookup(i,fd)^2;
    end
    Qlist = [Qlist QPower];
    Ilist = [Ilist IPower];
    
end 
figure;
subplot(2,1,1), plot(Qlist,'color',cc(1,:));
hold on;
subplot(2,1,2), plot(Ilist,'color',cc(2,:));
hold on;

%  for j = 1:N:size(Data,1)
%     
%     if(j+N > size(Data,1)||j+N > size(Data,1))
%         break
%     end
%     Qsample = Data(j:j+N,Q_COL);
%     Isample = Data(j:j+N,I_COL);
%     CorrectDistance = Data(j,DISTANCE_COL);
%     
%     
%     NFFT = 2^nextpow2(size(Qsample,1)); % Next power of 2 from length of y
%     Qfft = fft(Qsample,NFFT)/size(Qsample,1);
%     Qfft = 2*abs(Qfft(1:FFTCoe));
%     Ifft = fft(Isample,NFFT)/size(Isample,1);
%     Ifft = 2*abs(Ifft(1:FFTCoe));
%     %Qfft = Fs/2*linspace(0,1,NFFT/2+1);
%     MSETotal = inf;
%     Distance = 0;
%     % Plot single-sided amplitude spectrum.
%     for k = 5:5:100
%        QMSE = 0;
%        IMSE = 0;
%        for coe = 1:1:FFTCoe
%            QMSE = QMSE + (QLookup(k,coe) - Qfft(coe))^2;
%            IMSE = IMSE + (ILookup(k,coe) - Ifft(coe))^2;
%        end
%        QMSE = QMSE/FFTCoe;
%        IMSE = IMSE/FFTCoe;
%        if(MSETotal > QMSE + IMSE)
%            MSETotal = QMSE + IMSE;
%            Distance = k;
%        end
%     end
%     fprintf('%g, %g, %g\n',CorrectDistance,Distance,MSETotal);
%     if(abs(CorrectDistance - Distance) < 15)
%        Correct_Count = Correct_Count +1;
%     end
%     Count = Count + 1;
%  end
% 
% fprintf('Total Correct %g, Total Incorrect %g',Correct_Count/Count,1-(Correct_Count/Count));
%   % saveas(h,sprintf('%g_FFTQ',i),'jpg') 
%  
% plot(Ilist,Qlist);
% hold on;