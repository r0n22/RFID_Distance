clear all;


DataScript



for i = 5:5:100
    
   Q = [];
   I = [];
   
    for j = 1:10531
      if(Data(j,1) == i)
         Q = [Q Data(j,Q_COL)];
         I = [I Data(j,I_COL)];
         
      end
    end
    
    nbins = 30;
    %Q
    h = figure,  
    
    subplot(2,1,1),hist(Q, nbins)
    title(sprintf('%g cm Distance Histogram Q',i));
    xlabel('Q (db)');
    ylabel('Frequency');
    %saveas(h,sprintf('%g_HistQ',i),'jpg') 
    %I
   
    subplot(2,1,2), hist(I, nbins)
    title(sprintf('%g cm Distance Histogram I',i));
    xlabel('I (db)');
    ylabel('Frequency');
    saveas(h,sprintf('%g_Hist',i),'jpg') 
   
end