(function(){var e=window.cfx,l=window.sfx;e.motif="metro";var d=l["gauge.templates"];void 0!=d&&(d["Glow.fill"]="0,#FFFFFF",d.metroDashBorder='<T><T.R><Th K="borderGap">8</Th><s K="plotMargin">targetChart</s></T.R><C M="4"><B F="{B F}"/><B><B.F><L S="0,0" E="1,0"><G C="#10000000" O="0"/><G C="#10FFFFFF" O="1"/></L></B.F></B><g><g.RD><RD H="*"/><RD H="Auto"/></g.RD><C M="4,8,4,8" N="targetChart"/><B g.R="1" M="10,0,0,8" F="#00FFFFFF" H="20"><TextBlock M="8,0" Text="{B Title}" FontSize="10" VerticalAlignment="Center" HorizontalAlignment="Left" Foreground="{Binding Class=DashboardTitle.fill}" FontFamily="{Binding Class=DashboardTitle.font-family}"/></B></g></C></T>',
d.metroRadialDashBorder='<T><T.R><Th K="borderFactor">0.03</Th></T.R><V VW="100" VH="100"><E W="100" H="100" S="{Binding Class=Glow.fill}" A="0.5" ST="3"/></V></T>',d.metroRadialIndicator="RadialIndicatorRounded",d.metroRadialCap="RadialCapPlain",d.metroRadialGlare="<T/>",d.metroLinearDashBorder="<T/>",d.metroLinearGlare="<T/>",d.metroFillerHorizontal="LinearFillerSimple",d.metroFillerVertical="LinearFillerSimple",d.metroLinearBar='<T><C M="-6"><B F="{B F}" S="{N}" CR="2"/><B F="{N}" ST="2" S="#131616" StartCorner="3" Segments="2" CR="2"/><B F="{N}" ST="3" S="#282A2B" StartCorner="1" Segments="2" CR="2"/></C></T>',
d.TipBorderDefault='<T xmlns:x="a"><T.R><mc K="multConverter"/></T.R><C Padding="12"><B S="#808080" ST="2" F="{B F}" ><DockPanel N="container" M="8,9,8,3" Orientation="Vertical"><TextBlock Text="{B Title}" FontSize="{B FontSize, Converter={S multConverter},ConverterParameter=0.8}" V="{B TitleVisible}" HorizontalAlignment="Right" FontWeight="Bold" M="3,0,3,0"/><B H="1" S="{B Foreground}" ST="1" M="0,0,0,4" V="{B TitleVisible}"/></DockPanel></B></C></T>',d.metroPictoGraph='<T><T.R><s K="ratio">0.72454</s><s K="vertSpacing">0.1</s><s K="horzSpacing">0.2</s><s K="vertSpacingHive">0</s><s K="horzSpacingHive">0.2</s></T.R><V VW="17.389" VH="24"><g><P S="{B S}" F="{B F}" Reuse="true" D="M5.5,0.5B6,0.5,9.234,10.562,0,360M20.201,16.171c-0.167-2.299-2.931-4.547-5.179-5.017c-1.117-0.093-1.872,2.206-4.521,2.036c-2.585-0.167-3.312-2.129-4.399-2.129l0,0c-2.782,0-4.621,2.555-5.042,5.11c0,0-0.61,2.729-0.556,4.558c0.023,0.795,0.174,1.42,0.556,1.575c0.662,0.269,18.469,0.256,19.142,0c0.203-0.077,0.283-0.664,0.297-1.446C20.53,19.042,20.201,16.171,20.201,16.171z"/></g></V></T>',
d=new e.gauge.Palette,d.setColors([null,"#242527","#80FFFFFF","#1A1C1D","#A0FFFFFF",null,"#FFFFFF",null,"#80FFFFFF",null,"#80FFFFFF","#60FFFFFF",null,null,"#40FFFFFF",null,null,"#60FFFFFF",null,null,"#90FFFFFF",null,null,"#40FFFFFF","#40FFFFFF","#80FFFFFF","#80FFFFFF","#80FFFFFF","#A0FFFFFF","#FFFFFF",null,"#FFFFFF","#D0D0D0","#202020","#D0D0D0","#40FFFFFF","#40FFFFFF","#40FFFFFF","#FFFFFF","#90FFFFFF","#40FFFFFF","#60FFFFFF","#20FFFFFF","#FFFFFF","#90FFFFFF","#40FFFFFF","#60FFFFFF","#20FFFFFF"]),
e.gauge.Palette.setDefaultPalette(d));d=l["vector.templates"];void 0!=d&&(d["AxisY_Text.fill"]="0,#80FFFFFF",d["Glow.fill"]="0,#FFFFFF",d.metroBorder='<T><T.R><s K="plotMargin">targetChart</s></T.R><C M="4"><B F="{B F}"/><B><B.F><L S="0,0" E="1,0"><G C="#10000000" O="0"/><G C="#10FFFFFF" O="1"/></L></B.F></B><g><g.RD><RD H="*"/><RD H="Auto"/></g.RD><C M="8,8,8,8" N="targetChart"/><B g.R="1" M="10,0,0,8" F="#00FFFFFF" H="20"><TextBlock M="8,0" Text="{B Title}" FontSize="10" VerticalAlignment="Center" HorizontalAlignment="Left" Foreground="{Binding Class=DashboardTitle.fill}" FontFamily="{Binding Class=DashboardTitle.font-family}"/></B></g></C></T>',
d.metroLine="LineBasic",d.metroBar="BarBasic",d.metroGantt="GanttBasic",d.metroDoughnut="DoughnutBasic",d.metroPie="PieBasic",d.metroBubble="BubbleBasic",d.metroArea="AreaBasic",d.metroCurve="CurveBasic",d.metroCurveArea="CurveAreaBasic",d.metroPyramid="PyramidBasic",d.metroHighLow='<T><T.R><T K="lineTemplate"><C><Pl P="{B P}" S="{B S}" ST="{B ST}"/></C></T></T.R><Po P="{B P}" F="{B F}"/></T>',d.TipBorderDefault='<T xmlns:x="a"><T.R><mc K="multConverter"/></T.R><C Padding="12"><B S="#808080" ST="2" F="{B F}" ><DockPanel M="8,9,8,3" Orientation="Vertical"><DockPanel N="container" M="0,0,0,3" Orientation="Vertical"/><B H="1" S="{B Foreground}" ST="1" M="0,2,0,7" V="{B TitleVisible}"/><TextBlock Text="{B Title}" FontSize="{B FontSize, Converter={S multConverter},ConverterParameter=1.1}" V="{B TitleVisible}" HorizontalAlignment="Left" M="3,0,3,0"/></DockPanel></B></C></T>',
d.TipContentDefault='<T xmlns:x="a"><DockPanel Orientation="Horizontal" M="3,2,6,2"><TextBlock Text="{B SeriesT}" M="0,0,8,0"/><TextBlock Text="{B Value}" FontWeight="Bold" HorizontalAlignment="Right"/></DockPanel></T>',d.metroPictoGraph='<T><T.R><s K="ratio">0.72454</s><s K="vertSpacing">0.1</s><s K="horzSpacing">0.2</s><s K="vertSpacingHive">0</s><s K="horzSpacingHive">0.2</s></T.R><V VW="17.389" VH="24"><g><P S="{B S}" F="{B F}" Reuse="true" D="M5.5,0.5B6,0.5,9.234,10.562,0,360M20.201,16.171c-0.167-2.299-2.931-4.547-5.179-5.017c-1.117-0.093-1.872,2.206-4.521,2.036c-2.585-0.167-3.312-2.129-4.399-2.129l0,0c-2.782,0-4.621,2.555-5.042,5.11c0,0-0.61,2.729-0.556,4.558c0.023,0.795,0.174,1.42,0.556,1.575c0.662,0.269,18.469,0.256,19.142,0c0.203-0.077,0.283-0.664,0.297-1.446C20.53,19.042,20.201,16.171,20.201,16.171z"/></g></V></T>',
d=new e.Palette,d.setColors("#FFFFFF #90FFFFFF #40FFFFFF #60FFFFFF #20FFFFFF #88888888 #E0E0E0E0 #60E0E0E0 #40000000 #60000000 #90000000 #40777777 #60777777 #90777777 #40444444 #80444444 #606060 #80000000 #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #80000000 #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #80FFFFFF #242527 #242527 #00000000 #80FFFFFF #80FFFFFF #40FFFFFF #FFFFFF #20FFFFFF #80FFFFFF #80FFFFFF #00000000 #80FFFFFF #00000000 #80FFFFFF #00000000 #00000000 #80FFFFFF #20FFFFFF #80FFFFFF #00000000 #80FFFFFF #A0FFFFFF #00000000 #D0D0D0 #202020 #D0D0D0 #80FFFFFF #40FFFFFF #40FFFFFF".split(" ")),
e.Chart.setDefaultPalette(d));var c=function(){};e.motifs.metro=c;c.currItem=-1;c.fixedHueIndex=-1;c.availableHuesCount=7;c.availableSaturationsCount=4;c.useMultipleSaturations=!1;c.nextBackColor=function(){var b,h;-1==c.fixedHueIndex?b=(c.currItem+1)%c.availableHuesCount:(b=c.fixedHueIndex,h=(c.currItem+1)%c.availableSaturationsCount);var a="#FF0000";switch(b){case 0:if(c.useMultipleSaturations)switch(h){case 0:a="#2571EB";break;case 1:a="#0047ba";break;case 2:a="#2d5089";break;case 3:a="#9fbceb"}else a=
"#2571EB";break;case 1:if(c.useMultipleSaturations)switch(h){case 0:a="#1B6035";break;case 1:a="#117e3a";break;case 2:a="#439c65";break;case 3:a="#00bb46"}else a="#1B6035";break;case 2:if(c.useMultipleSaturations)switch(h){case 0:a="#DA9216";break;case 1:a="#ad8032";break;case 2:a="#80683d";break;case 3:a="#534937"}else a="#DA9216";break;case 3:if(c.useMultipleSaturations)switch(h){case 0:a="#88A927";break;case 1:a="#68880a";break;case 2:a="#aaca4e";break;case 3:a="#354700"}else a="#88A927";break;
case 4:if(c.useMultipleSaturations)switch(h){case 0:a="#8B0096";break;case 1:a="#731a7a";break;case 2:a="#aa4cb2";break;case 3:a="#d900ea"}else a="#8B0096";break;case 5:if(c.useMultipleSaturations)switch(h){case 0:a="#139603";break;case 1:a="#267a1c";break;case 2:a="#58b24d";break;case 3:a="#19ea00"}else a="#139603";break;case 6:if(c.useMultipleSaturations)switch(h){case 0:a="#3B1C81";break;case 1:a="#25076a";break;case 2:a="#563898";break;case 3:a="#9b88c5"}else a="#3B1C81"}c.currItem=-1==c.fixedHueIndex?
b:h;return a};c.useFixedHue=function(b,h){0<=b&&b<c.availableHuesCount&&(c.fixedHueIndex=b,c.useMultipleSaturations=h)};c.getStyleInfo=function(b){var c="";void 0!==b&&(b=b[0],void 0!==b&&(c=b[0]));b={isGroup:!1};b.name=c;b.isSingle=!1;b.isBullet=!1;b.sections=[];if(void 0!=c&&(c=c.toUpperCase(),0<=c.indexOf("SINGLE")&&(b.isSingle=!0,b.name=""),0<=c.indexOf("GROUP")&&(b.isGroup=!0,b.name="",b.name=""),0<=c.indexOf("BULLET")&&(b.isBullet=!0,b.name=""),0<=c.indexOf("SECTIONS"))){var a,d;a=c.indexOf("SECTIONS");
d=c.indexOf(":",a);0<d&&(a=d,d=c.indexOf("-",a),c=0<=d?c.substring(a+1,d):c.substring(a+1,c.length),b.sections=c.split(",",100));b.name=""}return b};c.global=function(b,d){var a=c.getStyleInfo(d);if(!a.isGroup){var e=c.nextBackColor(),k;k=-1==c.fixedHueIndex?"Border"+c.currItem:"Border"+c.fixedHueIndex;b.getDashboardBorder().setInsideColor(e);b.getBorder().setInsideColor(e);b.getDashboardBorder().setTag(k)}b.getMainScale().getTickmarks().getMedium().setVisible(!1);b.setFont("9pt 'Segoe UI', 'Lucida Grande'");
b.getToolTips().setFont("9pt 'Segoe UI', 'Lucida Grande'");return a};c.radial=function(b,d){var a=c.global(b,d);b.getDashboardBorder().setInsideGap(.1);var f=b.getMainScale();f.setAllowHalves(!1);null!=a.name&&(b.setStyle(a.name),"progress"==a.name&&f.getBar().setVisible(!0),"repeater"==a.name&&(f=b.getMainScale(),f.getCap().setVisible(!1),f.getTickmarks().getMajor().setStyle(e.gauge.TickmarkStyle.None),f.getTickmarks().getMedium().setStyle(e.gauge.TickmarkStyle.None),f.setPosition(.2),f.getTickmarks().getMajor().setPosition(.8),
a=f.getBar(),a.setThickness(1),a.setPosition(0),a=new e.gauge.Repeater,a.setPaintOff(!0),b.setMainIndicator(a)))};c.linear=function(b,d){var a=c.global(b,d),f=b.getMainScale(),k=f.getBar(),g=f.getMainIndicator();k.setVisible(!1);g.setSize(.2);g.setPosition(.35);a.isGroup&&(b.getBorder().setTemplate("<T/>"),b.getDashboardBorder().setTemplate("<T/>"));"repeater"==a.name&&(k=new e.gauge.Repeater,k.setPaintOff(!0),b.setMainIndicator(k));a.isBullet&&(f.setThickness(.8),f.setPosition(0),g.setSize(.25),
g.setPosition(.375),g.setTitle("Current"),g=new e.gauge.Marker,g.setSize(.4),g.setPosition(.5),g.setTitle("Target"),g.setTemplate("MarkerThinRectangle"),f.getIndicators().add(g),b.getDefaultAttributes().setSectionThickness(.5),b.getDefaultAttributes().setSectionPosition(.25));if(0<a.sections.length){for(var g=0,l,k=0;k<a.sections.length;k++)l=a.sections[k],f=new e.gauge.ScaleSection,f.setFrom(g),f.setTo(l),b.getMainScale().getSections().add(f),g=l;b.getMainScale().setMax(l)}};c.vert=function(b,d){c.linear(b,
d)};c.horz=function(b,d){c.linear(b,d)};c.chart=function(b,d){var a="";if(void 0!==d){var f=d[0];void 0!==f&&(a=f[0])}void 0!=a&&(a=a.toUpperCase(),"GROUP"==a&&b.getBorder().setTemplate("<T/>"));a=b.getAxisY().getGrids();a.getMajor().setVisible(!1);a.getMajor().setTickMark(e.TickMark.None);a.getMinor().setVisible(!1);a.getMinor().setTickMark(e.TickMark.None);a=b.getAxisY2().getGrids();a.getMajor().setVisible(!1);a.getMajor().setTickMark(e.TickMark.None);a.getMinor().setVisible(!1);a.getMinor().setTickMark(e.TickMark.None);
b.setBackColor(c.nextBackColor());a=-1==c.fixedHueIndex?"Border"+c.currItem:"Border"+c.fixedHueIndex;b.getBorder().setTag(a);b.getAllSeries().getBorder().setEffect(e.BorderEffect.None);b.getAllSeries().getBorder().setUseForLines(!1);b.getAllSeries().setMarkerStyle(e.MarkerStyle.Filled);b.getAllSeries().setMarkerSize(4);b.getAllSeries().getLine().setWidth(2);b.getAxisX().getLine().setWidth(1);b.setAxesStyle(e.AxesStyle.None);b.setFont("9pt 'Segoe UI', 'Lucida Grande'");b.getToolTips().setFont("9pt 'Segoe UI', 'Lucida Grande'");
b.getAllSeries().getStackedLabels().setFont("bold")};c.border=function(b,d){b.setInsideColor(c.nextBackColor());b.setTag(-1==c.fixedHueIndex?"Border"+c.currItem:"Border"+c.fixedHueIndex)};c.trend=function(b,d){b.getBorder().setInsideColor(c.nextBackColor());var a;a=-1==c.fixedHueIndex?"Border"+c.currItem:"Border"+c.fixedHueIndex;b.getBorder().setTag(a);b.getSecondaryValues().setAlphaForeground(1);b.getIndicator().setStyle(e.gauge.IndicatorStyle.ArrowVertical);b.getSecondaryValues().setSeparatorWidth(0);
a="";if(void 0!==d){var f=d[0];void 0!==f&&(a=f[0])}void 0!=a&&(0<=a.toUpperCase().indexOf("SINGLE")&&(b.getDelta().setVisible(!1),b.getPercentChange().setVisible(!1),b.getIndicator().setVisible(!1)),0<=a.toUpperCase().indexOf("GROUP")&&b.getBorder().setTemplate("<T/>"))};c.map=function(b,c){b.setShowAdditionalLayers(!1);b.setBackColor("#00000000")};c.heatmap=function(b,c){var a=b.getGradientStops();a.getItem(0).setColor("#FFFFFF");a.getItem(1).setColor("#A0A0A0")};c.equalizer=function(b,c){var a=
new e.equalizer.EqualizerItem;a.setColor("#A0FFFFFF");a.setCount(2);b.getTopItems().add(a);a=new e.equalizer.EqualizerItem;a.setColor("#70FFFFFF");a.setCount(1);b.getTopItems().add(a);b.setOffColor("#10FFFFFF")};c.pictograph=function(b,d){b.getBorder().setInsideColor(c.nextBackColor());var a;a=-1==c.fixedHueIndex?"Border"+c.currItem:"Border"+c.fixedHueIndex;b.getBorder().setTag(a)};c.hideCaptions=function(){l["vector.templates"].metroBorder='<T><T.R><s K="plotMargin">2</s></T.R><B M="4" F="{B F}"/></T>';
l["gauge.templates"].metroDashBorder='<T><T.R><Th K="borderGap">8</Th></T.R><B M="4" F="{B F}"/></T>'}})();
cfx.ToolTipAttributes.prototype.setLineMode=function(){var e=new cfx.ToolTipLineAttributes;e.getLine().setStyle(0);e.setBorderTemplate('<T xmlns:x="a"><T.R><mc K="multConverter"/></T.R><C Padding="{B Padding}"><B C.Left="-1" C.Top="0" F="{B F}" A="0.85" S="{B S}"><DockPanel N="container" Orientation="Vertical" M="10,10,10,10"><TextBlock Text="{B Title}" FontSize="{B FontSize, Converter={S multConverter},ConverterParameter=1}" V="{B TitleVisible}" HorizontalAlignment="Center" FontWeight="Normal" M="3,0,3,3" Foreground="{Binding Class=PointLabel.fill}"/><B H="1" S="{B Foreground}" ST="1" M="0,2,0,7" V="{B TitleVisible}"/></DockPanel></B></C></T>');e.setVerticalAlignment(0);
e.setY(0);e.setAlignment(1);0==this.getTriggerMode()&&this.setTriggerMode(1);this.setMode(e)};