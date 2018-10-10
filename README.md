# Temă
Să se citească o gramatică independentă de context sub formă de șir de caractere. Citirea se face de la tastatură și din fișier. Se va construi un meniu corespunzător. Regulile de citire se afișsează înaintea citirii și sunt următoarele:
1. Primul simbol din prima producțue reprezintă axioma (simbolul de start)
2. Simbolul de separare dintre producții este `$`
3. Simbolurile neterminale sunt scrise cu litere mari
4. Simbolurile terminale sunt scrise cu litere mici
5. Secvența vidă va fi `@`
6. Simbolul care marchează sfârșitul gramaticii este `&`
Se cere afișarea mulțimilor: <b>V<sub>N</sub>, V<sub>T</sub>, S, P</b>
## Exemplu de șir
`SAB$AaA$A@$Ba&` <br/>
S --> AB <br/>
A --> aA <br/>
A --> lambda <br/>
B --> a <br/>
V<sub>N</sub> = { A, B } <br/>
V<sub>T</sub> = { a, lambda } <br/>
