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
    
    h = scatter(I,Q,'filled')
    title(sprintf('%g cm Distance',i));
    xlabel('Q (db)');
    ylabel('I (db)');
    saveas(h,sprintf('%g_ScatterPlotIvQ',i),'jpg') 
end