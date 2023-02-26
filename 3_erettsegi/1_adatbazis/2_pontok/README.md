# [Pontok feladatsor](https://github.com/MolnAtt/SQL/tree/main/feladatsorok/Pontok)

## Szűrések
#### 1. Első síknegyedbe eső pontok *(+x;+y)*
```sql
SELECT x, y FROM P
WHERE y<=x AND 0<=y;
```

#### 2. Első vagy utolsó síknegyedbe eső pontok *(+x;+y) ∨ (+x;-y)*
```sql
SELECT x, y FROM P
WHERE 0<=x;
```

#### 3. Origó körüli 100 sugarú körbe eső pontok
```sql
SELECT x, y FROM P
WHERE x^2 + y^2 <= 100^2;
```



## Selectek
#### 1. 'X' tengelytől, 'y' tengelytől és 'origótól' való távolság
```sql
SELECT ABS(x) AS x_tavolsag, ABS(y) AS y_tavolsag, ROUND(SQR(x^2+y^2),2) AS origo_tavolsag
FROM P;
```



## Összesítések
#### 1. Kordinátatengelyre eső pontok
```sql
SELECT COUNT(*) FROM P
WHERE x=0 OR y=0;
```

#### 2. Y tengelyhez legközelebbi pont(ok)
```sql
SELECT TOP 1 x, y FROM P
ORDER BY ABS(y);
```

#### 3. X tengelyhez legközelebbi pont(ok)
```sql
SELECT TOP 1 x, y FROM P
ORDER BY ABS(x);
```

#### 4. Origóhoz legközelebbi pont(ok)
```sql
SELECT TOP 1 x, y FROM P
ORDER BY ABS(x^2+y^2);
```

#### 5. Origótól legtávolabbi pont(ok) 
```sql
SELECT TOP 1 x, y FROM P
ORDER BY ABS(x^2+y^2) DESC;
```

#### 6. Tengelyektől legtávolabbi pont(ok)
```sql
SELECT TOP 1 x, y FROM P
ORDER BY IIF(ABS(x)<ABS(y), ABS(x), ABS(y)) DESC;
```

#### 7. Origót -45°-ban metsző egyeneshez legközelebbi pont
```sql
SELECT TOP 1 x, y FROM P
ORDER BY ABS(x+y);
```



## Pontpárok
#### 1. Egymás fölött elhelyezkedő pontpárok
```sql
SELECT "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE P.x=P_1.x AND P.id < P_1.id;
```

#### 2. Egymás mellett elhelyezkedő pontpárok
```sql
SELECT "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE (P.y=P_1.y) AND (P.id < P_1.id);
```

#### 3. Egymásra eső pontpárok
```sql
SELECT "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE (P.x=P_1.x) AND (P.y=P_1.y) AND (P.id <> P_1.id);
```

#### 4. Origóra való tükörképek
```sql
SELECT "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE (P.x + P_1.x = 0) AND (P.y + P_1.y = 0);
```

#### 5. X tengelyre való tükörképek *(Pontpárok 1.)*
```sql
SELECT "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE (P.x=P_1.x) AND (P.id < P_1.id);
```

#### 6. Y tengelyre való tükörképek *(Pontpárok 2.)*
```sql
SELECT "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE (P.y=P_1.y) AND (P.id < P_1.id);
```

#### 7. Egymástól legtávolabb eső pontpár
```sql
SELECT TOP 1 "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE P.x < P_1.x AND P.y < P_1.y
AND 250 < ABS(P.x) AND 250 < ABS(P_1.x) AND 250 < ABS(P.y) AND 250 < ABS(P_1.y) --gépünk létezésben elfoglalt állapotának megőrzéséhez
ORDER BY  ABS(P_1.x-P.x) + ABS(P_1.y-P.y) DESC;
```

#### 8. Egymáshoz legközelebb eső pontpár
```sql
SELECT TOP 1 "( ("&P.x&" ; "&P.y&") , ("&P_1.x&" ; "&P_1.y&") )"
FROM P, P AS P_1
WHERE P.x < P_1.x AND P.y < P_1.y
ORDER BY  ABS(P_1.x-P.x) + ABS(P_1.y-P.y);
```



## Ponthármasok
#### 1. 
```sql
```

#### 2. 
```sql
```

#### 3. 
```sql
```

#### 4. 
```sql
```

#### 5. 
```sql
```

#### 6. 
```sql
```



## Pontnégyesek
#### 1. 
```sql
```

#### 2. 
```sql
```

#### 3. 
```sql
```

#### 4. 
```sql
```

#### 5. 
```sql
```

#### 6. 
```sql
```

#### 7. 
```sql
```



## Csoportosítások
#### 1. 
```sql
```

#### 2. 
```sql
```

#### 3. 
```sql
```