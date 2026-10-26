const fs = require('fs');
const path = require('path');
const http = require('http');
const { chromium } = require('playwright');
const pptxgen = require('pptxgenjs');

const out = '/workspace/тендер_Прокат_360';
const shots = path.join(out, 'скриншоты');
const html = path.join(out, 'Прототип_Прокат_360.html');
fs.mkdirSync(shots, { recursive: true });

async function captureScreens() {
  const server = http.createServer((req, res) => {
    const requested = decodeURIComponent((req.url || '/').split('?')[0]);
    const safe = requested === '/' ? path.basename(html) : requested.replace(/^\/+/, '');
    const target = path.resolve(out, safe);
    if (!target.startsWith(path.resolve(out)) || !fs.existsSync(target)) { res.writeHead(404); res.end('Not found'); return; }
    res.writeHead(200, { 'Content-Type': target.endsWith('.html') ? 'text/html; charset=utf-8' : 'application/octet-stream' });
    fs.createReadStream(target).pipe(res);
  });
  await new Promise(resolve => server.listen(45123, '127.0.0.1', resolve));
  const browser = await chromium.launch({ executablePath: '/usr/bin/chromium', headless: true, args: ['--no-sandbox', '--disable-gpu'] });
  const page = await browser.newPage({ viewport: { width: 1440, height: 1000 }, deviceScaleFactor: 1 });
  await page.goto('http://127.0.0.1:45123/', { waitUntil: 'domcontentloaded' });
  const screenNames = [
    ['operator', '01_панель_оператора.png'],
    ['issue', '02_новая_выдача.png'],
    ['return', '03_возврат_и_осмотр.png'],
    ['inventory', '04_инвентарь.png'],
    ['mechanic', '05_мастерская.png'],
    ['manager', '06_отчёты_менеджера.png'],
    ['login', '07_авторизация.png'],
  ];
  for (const [id, name] of screenNames) {
    await page.evaluate((screenId) => window.openScreen(screenId), id);
    await page.waitForTimeout(120);
    await page.screenshot({ path: path.join(shots, name) });
  }
  await browser.close();
  await new Promise(resolve => server.close(resolve));
}

const C = { navy: '12233F', blue: '1976D2', sky: 'EAF4FF', ink: '172033', muted: '667085', line: 'DDE5F0', green: '138A5A', amber: 'BD7600', red: 'C9343E', white: 'FFFFFF', bg: 'F6F8FC' };
const L = { w: 13.333, h: 7.5, margin: 0.55 };

function addText(slide, text, x, y, w, h, opts = {}) {
  slide.addText(text, { x, y, w, h, fontFace: 'Arial', color: C.ink, fontSize: 17, breakLine: false, margin: 0, fit: 'shrink', valign: 'mid', ...opts });
}
function box(slide, x, y, w, h, opts = {}) {
  slide.addShape('roundRect', { x, y, w, h, rectRadius: 0.08, fill: { color: opts.fill || C.white }, line: { color: opts.line || opts.fill || C.white, transparency: opts.transparency ?? 0 }, radius: 0.08 });
}
function header(slide, section, title, subtitle) {
  slide.background = { color: C.bg };
  addText(slide, section.toUpperCase(), 0.6, 0.36, 3.5, 0.22, { fontSize: 8.5, color: C.blue, bold: true, charSpacing: 1.3 });
  addText(slide, title, 0.6, 0.62, 12.0, 0.48, { fontSize: 25, bold: true, color: C.navy });
  if (subtitle) addText(slide, subtitle, 0.6, 1.14, 12.0, 0.3, { fontSize: 10.5, color: C.muted });
  slide.addShape('line', { x: 0.6, y: 1.52, w: 12.1, h: 0, line: { color: C.line, width: 1 } });
}
function footer(slide, n) {
  addText(slide, 'ООО «Северный код»  ·  Тендерный пакет', 0.6, 7.12, 5.0, 0.18, { fontSize: 7.5, color: '8A98A9' });
  addText(slide, String(n).padStart(2, '0'), 12.25, 7.10, 0.45, 0.2, { fontSize: 8.5, color: '8A98A9', align: 'right' });
}
function kpi(slide, x, y, w, label, value, hint, color = C.blue) {
  box(slide, x, y, w, 1.16, { fill: C.white, line: C.line });
  addText(slide, label, x + 0.18, y + 0.14, w - .35, .18, { fontSize: 8.5, color: C.muted, bold: true });
  addText(slide, value, x + .18, y + .38, w - .35, .35, { fontSize: 21, color, bold: true });
  addText(slide, hint, x + .18, y + .82, w - .35, .18, { fontSize: 7.5, color: C.muted });
}
function bullet(slide, x, y, title, desc, color = C.blue) {
  slide.addShape('ellipse', { x, y: y + .04, w: .16, h: .16, fill: { color }, line: { color } });
  addText(slide, title, x + .28, y, 4.9, .21, { fontSize: 12, bold: true, color: C.navy });
  addText(slide, desc, x + .28, y + .25, 4.9, .32, { fontSize: 9.5, color: C.muted, valign: 'top' });
}
function pill(slide, x, y, text, fill, color) {
  box(slide, x, y, 1.0, .28, { fill, line: fill });
  addText(slide, text, x + .05, y + .03, .9, .18, { fontSize: 7.5, color, bold: true, align: 'center' });
}
function image(slide, file, x, y, w, h) { slide.addImage({ path: file, x, y, w, h, sizing: { type: 'contain', x, y, w, h } }); }

function buildPpt() {
  const pptx = new pptxgen();
  pptx.layout = 'LAYOUT_WIDE';
  pptx.author = 'ООО «Северный код»';
  pptx.subject = 'Тендерный пакет Прокат 360';
  pptx.title = 'Прокат 360';
  pptx.company = 'ООО «Северный код»';
  pptx.lang = 'ru-RU';
  pptx.theme = { headFontFace: 'Arial', bodyFontFace: 'Arial', lang: 'ru-RU' };
  pptx.defineLayout({ name: 'CUSTOM_WIDE', width: L.w, height: L.h });
  pptx.layout = 'CUSTOM_WIDE';

  let s = pptx.addSlide();
  s.background = { color: C.navy };
  s.addShape('rect', { x: 8.5, y: 0, w: 4.84, h: 7.5, fill: { color: C.blue, transparency: 8 }, line: { color: C.blue, transparency: 100 } });
  s.addShape('arc', { x: 8.0, y: 1.0, w: 4.2, h: 4.2, adjustPoint: .3, line: { color: '8DCCFF', transparency: 35, width: 2 }, adjustPoint: 0.2 });
  s.addShape('arc', { x: 9.1, y: 2.1, w: 2.8, h: 2.8, line: { color: 'FFFFFF', transparency: 55, width: 2 } });
  box(s, .68, .66, 1.18, .42, { fill: C.blue, line: C.blue }); addText(s, 'ТЕНДЕР 2026', .76, .75, 1.02, .2, { fontSize: 8, color: C.white, bold: true, align: 'center' });
  addText(s, 'Прокат 360', .7, 1.68, 7.3, .72, { fontSize: 37, color: C.white, bold: true });
  addText(s, 'Единая система для выдачи, осмотра, ремонта и контроля просрочек', .72, 2.55, 6.7, .52, { fontSize: 17, color: 'D9E9FF', bold: false, valign: 'top' });
  addText(s, 'Рабочие места: оператор · механик · менеджер', .72, 3.28, 6.0, .25, { fontSize: 10.5, color: 'B8CDE6' });
  s.addShape('line', { x: .72, y: 5.65, w: 6.0, h: 0, line: { color: '4E6E94', width: 1 } });
  addText(s, 'ООО «Северный код»', .72, 5.88, 4.0, .3, { fontSize: 12, color: C.white, bold: true });
  addText(s, 'Срок: 12 рабочих недель  ·  Бюджет: 1 350 160 ₽', .72, 6.28, 6.5, .25, { fontSize: 10, color: 'B8CDE6' });
  addText(s, '01', 12.3, 7.08, .4, .2, { fontSize: 8.5, color: 'D9E9FF', align: 'right' });

  s = pptx.addSlide(); header(s, 'Проблема', 'Бумажный журнал не управляет состоянием инвентаря', 'Ошибки в статусах приводят к конфликтам с клиентами, простоям и потерянной выручке');
  const problemCards=[['Спор о поломке','Нет фото и записи состояния на момент выдачи','C9343E'],['Просрочка обнаружена вечером','Оператор узнаёт о ней только при ручной сверке журнала','BD7600'],['Неисправный предмет числится свободным','Устная передача информации не блокирует повторную выдачу','7559D8']];
  problemCards.forEach((p,i)=>{ const x=.6+i*4.1; box(s,x,2.0,3.75,2.25,{fill:C.white,line:C.line}); s.addShape('ellipse',{x:x+.22,y:2.24,w:.35,h:.35,fill:{color:p[2]},line:{color:p[2]}}); addText(s,String(i+1),x+.22,2.32,.35,.12,{fontSize:8,color:C.white,bold:true,align:'center'}); addText(s,p[0],x+.22,2.78,3.2,.36,{fontSize:14,bold:true,color:C.navy}); addText(s,p[1],x+.22,3.33,3.2,.52,{fontSize:10,color:C.muted,valign:'top'}); });
  box(s,.6,4.72,12.1,1.37,{fill:'FFF8E9',line:'F7DCA2'}); addText(s,'Целевая картина',.85,4.98,2.1,.2,{fontSize:10,color:C.amber,bold:true}); addText(s,'Оператор видит только доступный инвентарь, просрочка появляется в течение 5 минут, а любой дефект создаёт маршрут «карантин → ремонт → проверка».',.85,5.31,11.2,.36,{fontSize:15,color:C.navy,bold:true}); footer(s,2);

  s = pptx.addSlide(); header(s, 'Решение', '«Прокат 360» — одна история для каждой единицы инвентаря', 'Вместо разрозненных записей — единый сквозной процесс от выдачи до отчёта');
  const stages=[['1','Выдача','Договор, залог, чек-лист и фото до выдачи'],['2','Возврат','Сверка состояния, доплата, новые фото'],['3','Карантин','Подозрение на дефект сразу исключает повторную выдачу'],['4','Ремонт','Механик получает заявку и ведёт работу'],['5','Проверка','Только подтверждённо исправная единица снова свободна']];
  stages.forEach((a,i)=>{const x=.63+i*2.48; box(s,x,2.06,2.14,2.5,{fill:C.white,line:C.line}); s.addShape('ellipse',{x:x+.18,y:2.3,w:.38,h:.38,fill:{color:i===2?C.amber:C.blue},line:{color:i===2?C.amber:C.blue}});addText(s,a[0],x+.18,2.39,.38,.13,{fontSize:9,color:C.white,bold:true,align:'center'});addText(s,a[1],x+.18,2.88,1.76,.24,{fontSize:13,bold:true,color:C.navy});addText(s,a[2],x+.18,3.32,1.76,.62,{fontSize:9.2,color:C.muted,valign:'top'});if(i<4)s.addShape('chevron',{x:x+2.18,y:3.1,w:.22,h:.28,fill:{color:'A9B8C8'},line:{color:'A9B8C8'}});});
  box(s,.63,5.05,12.0,.72,{fill:C.sky,line:C.sky});addText(s,'Отличие от универсальных сервисов: компактный сценарий для стойки проката, русскоязычные формы и фиксированная проектная стоимость без платы за каждого сотрудника.',.9,5.23,11.45,.24,{fontSize:12,color:'1A4D7A',bold:true,align:'center'}); footer(s,3);

  s = pptx.addSlide(); header(s, 'Функции', 'Все критичные операции закрыты в первой версии', '16 функциональных требований: от QR-карточки инвентаря до аудита и резервного копирования');
  bullet(s,.75,2.0,'Оператор: выдача и возврат','Договор, тариф, залог, обязательный фотоосмотр и акт в PDF.');
  bullet(s,.75,3.0,'Контроль статусов','«Ремонт» и «карантин» физически не попадут в новую выдачу.',C.amber);
  bullet(s,.75,4.0,'Просрочки в реальном времени','Подсветка и уведомление не позднее чем через 5 минут.',C.red);
  bullet(s,6.9,2.0,'Мастерская','Очередь дефектов, приоритеты, ответственный и контрольный осмотр.');
  bullet(s,6.9,3.0,'Менеджер','Загрузка парка, выручка, простои, просрочки и экспорт.',C.green);
  bullet(s,6.9,4.0,'Безопасность','Роли, HTTPS, аудит действий и ежедневные резервные копии.',C.navy);
  box(s,.75,5.38,11.8,.53,{fill:'EFFAF4',line:'D5F0E1'});addText(s,'Персональные данные минимизированы: номер паспорта в системе не хранится; учёт залога ведётся по типу, сумме и ответственному.',1.0,5.55,11.3,.18,{fontSize:10.5,color:'0C6A43',bold:true,align:'center'});footer(s,4);

  s = pptx.addSlide(); header(s, 'Интерфейсы', 'Прототип рассчитан на быстрые решения на стойке', 'Семь экранов: авторизация, оператор, выдача, возврат, инвентарь, мастерская и отчёты');
  image(s,path.join(shots,'01_панель_оператора.png'),.62,1.82,6.0,4.12); image(s,path.join(shots,'02_новая_выдача.png'),6.75,1.82,6.0,4.12);
  addText(s,'Панель оператора: доступность, выдачи и просрочки',.85,6.17,5.55,.2,{fontSize:9.5,color:C.muted,align:'center'});addText(s,'Новая выдача: договор, залог и осмотр до выдачи',6.99,6.17,5.55,.2,{fontSize:9.5,color:C.muted,align:'center'});footer(s,5);

  s = pptx.addSlide(); header(s, 'Архитектура', 'Простое веб-решение с предсказуемой эксплуатацией', 'Клиент работает в браузере на ПК или планшете; бизнес-правила и доступ контролируются сервером');
  const nodes=[['Оператор\nМеханик\nМенеджер',.85,2.45,2.1,1.25,C.white,C.navy],['React\nвеб-интерфейс',4.05,2.45,2.1,1.25,C.sky,'1A4D7A'],['NestJS API\nроли и бизнес-правила',7.25,2.45,2.1,1.25,'EAF4FF','1A4D7A'],['PostgreSQL\nдоговоры и статусы',10.45,1.83,2.1,1.08,C.white,C.navy],['S3-хранилище\nфото и PDF',10.45,3.25,2.1,1.08,C.white,C.navy]];
  nodes.forEach(n=>{box(s,n[1],n[2],n[3],n[4],{fill:n[5],line:C.line});addText(s,n[0],n[1]+.14,n[2]+.30,n[3]-.28,n[4]-.42,{fontSize:12,color:n[6],bold:true,align:'center',breakLine:true});});
  [[2.98,3.07,1.02],[6.18,3.07,1.02],[9.38,2.68,1.02],[9.38,3.45,1.02]].forEach(a=>s.addShape('line',{x:a[0],y:a[1],w:a[2],h:0,line:{color:'84A6CA',width:1.8,beginArrowType:'none',endArrowType:'triangle'}}));
  box(s,3.28,5.23,6.76,.73,{fill:'FFF8E9',line:'F7DCA2'});addText(s,'Защита: HTTPS · пароли в стойких хешах · роли доступа · неизменяемый аудит · ежедневный бэкап. Цели восстановления: RPO 24 ч, RTO 4 ч.',3.58,5.43,6.16,.24,{fontSize:10,color:'704700',bold:true,align:'center'});footer(s,6);

  s = pptx.addSlide(); header(s, 'Срок и бюджет', 'Реализация за 12 рабочих недель в пределах лимита', 'Итоговая цена включает 12 % резерв на согласованные риски');
  kpi(s,.65,1.9,2.8,'СРОК', '12 недель', 'не более 3 месяцев',C.blue);kpi(s,3.68,1.9,2.8,'БЮДЖЕТ', '1,35 млн ₽', 'включая резерв 144 660 ₽',C.green);kpi(s,6.71,1.9,2.8,'ПОЛЬЗОВАТЕЛИ', '20–50', '3 ключевые роли',C.navy);kpi(s,9.74,1.9,2.8,'TCO 3 ГОДА', '1,61 млн ₽', 'с поддержкой и инфраструктурой',C.violet||'7559D8');
  const costs=[['Разработка',737.5,C.blue],['Анализ и дизайн',245,C.green],['Тестирование',85,C.amber],['Внедрение, поддержка, инфраструктура',138,C.navy],['Резерв',144.66,'7559D8']];
  addText(s,'Структура бюджета, тыс. ₽',.7,3.48,3.5,.22,{fontSize:12,bold:true,color:C.navy});costs.forEach((r,i)=>{const y=3.9+i*.42;addText(s,r[0],.72,y,2.6,.16,{fontSize:9.2,color:C.muted});s.addShape('rect',{x:3.15,y:y+.01,w:r[1]/800*4.1,h:.15,fill:{color:r[2]},line:{color:r[2]}});addText(s,String(r[1]).replace('.',',')+'',7.42,y,0.55,.16,{fontSize:9.2,color:C.ink,align:'right'});});
  box(s,8.65,3.45,3.55,2.42,{fill:C.white,line:C.line});addText(s,'Календарный план',8.93,3.73,3.0,.2,{fontSize:12,bold:true,color:C.navy});['Анализ','Проектирование','Разработка','Тестирование','Внедрение'].forEach((t,i)=>{const ys=4.14+i*.29;addText(s,t,8.93,ys,1.22,.14,{fontSize:8,color:C.muted});const x=10.22+[0,0.42,0.85,2.35,2.85][i]; const w=[.42,.43,1.5,.5,.28][i];s.addShape('rect',{x,y:ys+.01,w,h:.12,fill:{color:[C.blue,'4EA2E8',C.green,C.amber,'7559D8'][i]},line:{color:[C.blue,'4EA2E8',C.green,C.amber,'7559D8'][i]}});});addText(s,'1       3       5       7       9      11      12',10.22,5.62,1.7,.14,{fontSize:6.5,color:C.muted});footer(s,7);

  s = pptx.addSlide(); header(s, 'Внедрение', 'Начинаем с пилота — затем быстро масштабируем на весь пункт', 'Параллельная работа с бумажным журналом сохраняется только на ограниченный период контроля');
  const steps=[['Подготовка','Аудит рабочих мест, резервная копия, инвентаризация'],['Настройка','Развёртывание, роли, тарифы, категории'],['Миграция','Загрузка справочника и актуальных договоров, сверка'],['Пилот','2–3 сотрудника, реальные операции, реестр замечаний'],['Обучение','Практика по ролям, памятки, тестовый стенд'],['Полный запуск','Все пользователи, контроль первой смены']];
  steps.forEach((r,i)=>{let x=.66+i*2.05;box(s,x,2.1,1.75,2.7,{fill:C.white,line:C.line});s.addShape('ellipse',{x:x+.17,y:2.34,w:.31,h:.31,fill:{color:i===3?C.amber:C.blue},line:{color:i===3?C.amber:C.blue}});addText(s,String(i+1),x+.17,2.42,.31,.1,{fontSize:7.5,color:C.white,bold:true,align:'center'});addText(s,r[0],x+.16,2.9,1.45,.23,{fontSize:11.2,bold:true,color:C.navy});addText(s,r[1],x+.16,3.35,1.45,.65,{fontSize:8.5,color:C.muted,valign:'top'});});
  box(s,.66,5.33,12.0,.64,{fill:'EFFAF4',line:'D5F0E1'});addText(s,'Обучение: операторы — 2 часа; механики — 1,5 часа; менеджеры — 1,5 часа. После запуска — 12 месяцев сопровождения и мониторинга резервных копий.',.92,5.54,11.5,.18,{fontSize:10.5,color:'0C6A43',bold:true,align:'center'});footer(s,8);

  s = pptx.addSlide(); header(s, 'Риски и откат', 'Контролируем переход так, чтобы прокат не остановился', 'Риски обрабатываются до запуска; для критических ситуаций предусмотрен короткий план отката');
  const risks=[['Неверный стартовый реестр','12','Инвентаризация + тестовая миграция + акт сверки',C.red],['Фотоосмотр пропускают','12','Обязательный чек-лист, обучение, контроль первых смен',C.amber],['Сотрудники не принимают процесс','9','Пилот с ключевыми пользователями, памятки и поддержка',C.blue],['Недоступность сети/сервера','10','Мониторинг, бэкапы, аварийная бумажная форма',C.navy]];
  risks.forEach((r,i)=>{const y=1.95+i*.65;box(s,.68,y,7.5,.52,{fill:C.white,line:C.line});addText(s,r[0],.87,y+.15,2.25,.15,{fontSize:9.3,bold:true,color:C.navy});box(s,3.25,y+.12,.52,.23,{fill:r[3],line:r[3]});addText(s,r[1],3.25,y+.17,.52,.09,{fontSize:7.5,color:C.white,bold:true,align:'center'});addText(s,r[2],3.95,y+.15,3.95,.15,{fontSize:8.5,color:C.muted});});
  box(s,8.65,1.94,3.93,3.38,{fill:'FFF8E9',line:'F7DCA2'});addText(s,'Когда откатываемся',8.94,2.22,3.28,.2,{fontSize:12,bold:true,color:C.amber});addText(s,'• несоответствие >1 % активных договоров\n• выдача или возврат не работают >30 минут\n• критический дефект не устранён за 4 часа\n\nРешение: менеджер заказчика + руководитель проекта.',8.94,2.69,3.17,1.7,{fontSize:10,color:'704700',breakLine:true,valign:'top'});addText(s,'Откат: бумажная форма → снимок данных → восстановление на отдельном контуре → сверка активных договоров → повторный пилот.',8.94,4.54,3.17,.48,{fontSize:9,color:'704700',bold:true,valign:'top'});footer(s,9);

  s = pptx.addSlide(); s.background={color:C.navy};
  addText(s,'Почему «Прокат 360»',.7,.68,8.0,.5,{fontSize:28,color:C.white,bold:true});addText(s,'Измеримый эффект, понятное внедрение и решение в рамках тендерного лимита.',.72,1.3,7.4,.3,{fontSize:12,color:'B8CDE6'});
  const res=[['≤ 5 минут','оформление типовой выдачи'],['≤ 5 минут','обнаружение просрочки'],['0 случаев','повторной выдачи инвентаря в ремонте'],['100 %','актуальных статусов на контрольной выборке']];
  res.forEach((r,i)=>{const x=.72+(i%2)*4.15,y=2.1+Math.floor(i/2)*1.6;box(s,x,y,3.75,1.16,{fill:'1A3453',line:'31557E'});addText(s,r[0],x+.2,y+.24,3.35,.3,{fontSize:20,color:'8DCCFF',bold:true});addText(s,r[1],x+.2,y+.72,3.35,.18,{fontSize:9.5,color:'D9E9FF'});});
  box(s,9.35,2.1,2.6,3.2,{fill:C.blue,line:C.blue});addText(s,'1,35\nмлн ₽',9.65,2.62,2.0,.72,{fontSize:27,color:C.white,bold:true,align:'center',breakLine:true});addText(s,'12 рабочих недель\n20–50 пользователей\n3 роли',9.65,3.64,2.0,.7,{fontSize:11,color:'E6F3FF',align:'center',breakLine:true});addText(s,'Готовы начать с анализа процессов и прототипа.',.72,6.15,10.0,.3,{fontSize:15,color:C.white,bold:true});addText(s,'ООО «Северный код» · Тендерный пакет · 2026',.72,6.65,6.5,.2,{fontSize:8.5,color:'B8CDE6'});addText(s,'10',12.25,7.08,.42,.2,{fontSize:8.5,color:'D9E9FF',align:'right'});
  return pptx.writeFile({ fileName: path.join(out, 'Презентация_Прокат_360.pptx') });
}

(async () => { await captureScreens(); await buildPpt(); console.log('Артефакты собраны.'); })().catch(err => { console.error(err); process.exit(1); });
