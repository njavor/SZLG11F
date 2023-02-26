# [Diákmunka érettségi feladatsor](https://github.com/MolnAtt/SQL/blob/main/feladatsorok/erettsegi/diakmunka/di%C3%A1kmunka%20F/di%C3%A1kmunka.pdf)

### 2. Négyórás kisegítői állások
```sql
SELECT datum, oradij FROM munka
WHERE oraszam = 4 AND allas = "kisegítő";
```

### 3. Betöltetlen állások dátuma
```sql
SELECT DISTINCT datum FROM munka
WHERE diakaz IS NULL;
```

### 4. Munkalehetőségek száma
```sql
SELECT COUNT(*) FROM munka;
```

### 5. Jelentés az álláslehetőségekről
```sql
SELECT datum, allas, oradij, oraszam
FROM munka
ORDER BY datum, oradij DESC;
```

### 6. Átlagosan legmagasabb óradíjat meghirdető cég(ek)
```sql
SELECT TOP 1 nev, ROUND(SUM(oradij) /COUNT(*), 2) AS atlag
FROM munkaado INNER JOIN munka ON munkaado.mhelyid = munka.mhelyid
GROUP BY munkaado.nev
ORDER BY SUM(oradij) /COUNT(*) DESC;
```

### 7. Diákonkénti összkereset
```sql
SELECT nev, SUM(oradij*oraszam) AS osszkereset
FROM diak INNER JOIN munka ON diak.diakaz = munka.diakaz
GROUP BY nev;
```

### 8. '88-as vagy fiatalabb, kézbesítői vagy futári munkát végzők
```sql
SELECT nev
FROM diak INNER JOIN munka ON diak.diakaz = munka.diakaz
WHERE 1988 <= YEAR(szulido) AND (allas = "kézbesítő" OR allas = "futár");
```

### 9. Kos Péterrel együtt dolgozók
```sql
SELECT diak.nev, datum
FROM diak INNER JOIN munka ON diak.diakaz = munka.diakaz
WHERE nev <> "Kos Péter"
AND mhelyid IN (SELECT mhelyid FROM diak INNER JOIN munka ON diak.diakaz = munka.diakaz WHERE diak.nev="Kos Péter")
AND datum IN (SELECT datum FROM diak INNER JOIN munka ON diak.diakaz = munka.diakaz WHERE diak.nev="Kos Péter");
```