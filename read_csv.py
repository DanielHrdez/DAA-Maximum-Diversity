import pandas as pd
bb = pd.read_csv('csv/BrunchBound.csv')
bb_2 = bb[bb['Lower Bound'] == 'Grasp'][bb['Strategy'] == 'Lowest Bound']
with open('csv/BB_Grasp_LB.csv', 'w') as f:
    f.write(bb_2.to_csv(index=False))