/** cellreport.viewer (ver11.0.1) Copyright 2021 Advance Software Co., Ltd.  */
import Zlib from './gunzip.min.js'
var CellReport = CellReport || {}
CellReport.Viewer = function (viewercontainerId, locale) {
  this._init(viewercontainerId, locale)
}
CellReport.Viewer.prototype._init = function (viewercontainerId, locale) {
  var ErrorResources = {
      NoError: { no: 0, message: { ja: '', en: '' } },
      ViewerContainer: {
        no: 1,
        message: {
          ja: '\u5f15\u6570(viewerContainer)\u306e\u6307\u5b9a\u304c\u4e0d\u6b63\u3067\u3059',
          en: 'Invalid argument(viewerContainer) specification'
        }
      },
      NoDocument: {
        no: 2,
        message: {
          ja: 'SVG\u30c9\u30ad\u30e5\u30e1\u30f3\u30c8\u304c\u898b\u3064\u304b\u308a\u307e\u305b\u3093',
          en: 'Not exists SVG documents'
        }
      },
      UriNotfound: {
        no: 3,
        message: {
          ja: '\u6307\u5b9a\u3057\u305f\u30da\u30fc\u30b8\u304c\u898b\u3064\u304b\u308a\u307e\u305b\u3093',
          en: 'Page not found'
        }
      },
      UnsupportedDocument: {
        no: 4,
        message: {
          ja: '\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u306a\u3044\u30c9\u30ad\u30e5\u30e1\u30f3\u30c8\u3067\u3059',
          en: 'Not supported Documents'
        }
      },
      CancelOperation: {
        no: 5,
        message: {
          ja: '\u51e6\u7406\u3092\u4e2d\u6b62\u3057\u307e\u3057\u305f',
          en: 'CancelOperation'
        }
      },
      IllegalOperation: {
        no: 6,
        message: { ja: '\u4e0d\u6b63\u306a\u64cd\u4f5c\u3067\u3059', en: 'Illegal operation' }
      },
      Documentnotloaded: {
        no: 7,
        message: {
          ja: '\u30c9\u30ad\u30e5\u30e1\u30f3\u30c8\u304c\u8aad\u307f\u8fbc\u307e\u308c\u3066\u3044\u307e\u305b\u3093',
          en: 'Document not loaded'
        }
      },
      NoExcelData: {
        no: 8,
        message: {
          ja: '\u30c9\u30ad\u30e5\u30e1\u30f3\u30c8\u306bExcel\u30c7\u30fc\u30bf\u306f\u542b\u307e\u308c\u3066\u3044\u307e\u305b\u3093',
          en: 'ExcelData not included'
        }
      },
      NoPdfData: {
        no: 9,
        message: {
          ja: '\u30c9\u30ad\u30e5\u30e1\u30f3\u30c8\u306bPdf\u30c7\u30fc\u30bf\u306f\u542b\u307e\u308c\u3066\u3044\u307e\u305b\u3093',
          en: 'PdfData not included'
        }
      },
      InternalException: {
        no: 99,
        message: {
          ja: '\u5185\u90e8\u30a8\u30e9\u30fc\u304c\u767a\u751f\u3057\u307e\u3057\u305f\u3002',
          en: 'An unexpected error occurred in internal processing'
        }
      }
    },
    ViewerItemResources = {
      sButtonOpenMenu: { ja: '\u958b\u304f', en: 'OpenFile' },
      sFileDialog: { ja: '\u4fdd\u5b58', en: 'Save' },
      sButtonPrintMenu: { ja: '\u5370\u5237', en: 'Print' },
      sSubMenuPrint: { ja: '\u5370\u5237', en: 'Print' },
      sButtonSaveMenu: { ja: '\u4fdd\u5b58', en: 'Save' },
      sSubMenuSave: { ja: '\u4fdd\u5b58', en: 'Save' },
      sButtonPrintAll: { ja: '\u5168\u30da\u30fc\u30b8', en: 'All pages' },
      sButtonPrintCurrent: { ja: '\u73fe\u5728\u306e\u30da\u30fc\u30b8', en: 'Current page' },
      sButtonSaveSvgAll: { ja: 'SVG', en: 'SVG' },
      sButtonSaveSvgCurrent: {
        ja: 'SVG(\u3053\u306e\u30da\u30fc\u30b8)',
        en: 'SVG(Currentpage)'
      },
      sButtonSaveExcel: { ja: 'Excel', en: 'Excel' },
      sButtonSavePdf: { ja: 'PDF', en: 'PDF' },
      sButtonFirst: { ja: '\u5148\u982d\u30da\u30fc\u30b8\u3078', en: 'Move to firstpage' },
      sButtonPrev: { ja: '\u524d\u30da\u30fc\u30b8\u3078', en: 'Move to previous page' },
      sButtonNext: { ja: '\u6b21\u30da\u30fc\u30b8\u3078', en: 'Move to next page' },
      sButtonLast: { ja: '\u6700\u7d42\u30da\u30fc\u30b8\u3078', en: 'Move to Last page' },
      sLabelTotalPage: { ja: '\u7dcf\u30da\u30fc\u30b8\u6570', en: 'Total number of pages' },
      sTextCurrentPage: { ja: '\u73fe\u5728\u306e\u30da\u30fc\u30b8', en: 'current page' },
      sButtonZoomIn: { ja: '\u62e1\u5927', en: 'Zoom in' },
      sButtonZoomOut: { ja: '\u7e2e\u5c0f', en: 'Zoom out' },
      sSelectZoom: { ja: '\u62e1\u5927\u7e2e\u5c0f\u7387', en: 'Scaling rate' },
      sOptionZoom2: { ja: '\u76f4\u63a5\u5165\u529b', en: 'User setting' },
      sOptionZoom3: { ja: '\u5168\u3066\u8868\u793a', en: 'Full' },
      sOptionZoom4: { ja: '\u6a2a\u306b\u3042\u308f\u305b\u308b', en: 'Aside' },
      sOptionZoom5: { ja: '\u7e26\u306b\u3042\u308f\u305b\u308b', en: 'Striplength' },
      sOptionZoom6: { ja: '50%', en: '50%' },
      sOptionZoom7: { ja: '100%', en: '100%' },
      sOptionZoom8: { ja: '300%', en: '300%' },
      sOptionZoom9: { ja: '600%', en: '600%' },
      sTextZoom: { ja: '\u76f4\u63a5\u5165\u529b', en: 'User setting' },
      sPrintPaperSize: { ja: '\u7528\u7d19\u30b5\u30a4\u30ba', en: 'PaperSize' },
      sPrintPageLandscape: { ja: '\u6a2a', en: 'Landscape' },
      sPrintPageportrait: { ja: '\u7e26', en: 'Portrait' }
    },
    svgBlob = undefined,
    svgTextDocument = '',
    svgInlineDocument = undefined,
    svgFileType = '.svg',
    svgDocumentid = 'cellReport',
    internalError = ErrorResources.NoError,
    totalPage = 1,
    viewPage = 0,
    pageZoom = 100,
    viewerLocale = 'ja',
    defaultViewerLocale = 'en',
    internalPageZoom = 100,
    iframeHeight = 100,
    iframeWidth = 100,
    idViewerContainer = viewercontainerId,
    sViewerContainer = '#' + idViewerContainer,
    imageLoadingb64 =
      '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',
    saveExcelFileName = '',
    savePdfFileName = '',
    saveSvgFileName = '',
    visibilityToolBar = true,
    visibilityOpenMenuButton = false,
    visibilityPrintMenuButton = true,
    visibilitySaveMenuButton = true,
    visibilityPrintAllButton = true,
    visibilityPrintCurrentButton = true,
    visibilitySaveSvgAllButton = false,
    visibilitySaveSvgCurrentButton = false,
    visibilitySaveExcelButton = true,
    visibilitySavePdfButton = true,
    visibilityPageFirstButton = true,
    visibilityPagePrevButton = true,
    visibilityPageNextButton = true,
    visibilityPageLastButton = true,
    visibilityZoomButton = true,
    visibilityZoomSelect = true,
    visibilityStatusBar = true,
    validOpenMenuButton = false,
    validPrintButton = false,
    validSaveSvgButton = false,
    validSaveExcelButton = false,
    validSavePdfButton = false,
    validPageFirstPrevButton = false,
    validPageNextLastButton = false,
    validZoomInButton = false,
    validZoomOutButton = false,
    validZoom = false,
    minimumLineWeight = 0,
    applyPageSize = false,
    idPrefix = 'o' + Math.random().toString(36).slice(-8),
    idViewer = idPrefix + 'Viewer',
    idItemBody = idPrefix + 'ItemBody',
    idAnimation = idPrefix + 'Animation',
    idToolBar = idViewer + 'ToolBar',
    idButtonOpenMenu = idViewer + 'OpenMenu',
    idFileDialog = idViewer + 'FileDialog',
    idButtonPrintMenu = idViewer + 'PrintMenu',
    idSubMenuPrint = idViewer + 'SubMenuPrint',
    idButtonSaveMenu = idViewer + 'SaveMenu',
    idSubMenuSave = idViewer + 'SubMenuSave',
    idButtonPrintAll = idViewer + 'PrintAll',
    idButtonPrintCurrent = idViewer + 'PrintCurrent',
    idButtonSaveSvgAll = idViewer + 'SaveSvgAll',
    idButtonSaveSvgCurrent = idViewer + 'SaveSvgCurrent',
    idButtonSaveExcel = idViewer + 'SaveExcel',
    idButtonSavePdf = idViewer + 'SavePdf',
    idButtonFirst = idViewer + 'First',
    idButtonPrev = idViewer + 'Prev',
    idButtonNext = idViewer + 'Next',
    idButtonLast = idViewer + 'Last',
    idLabelTotalPage = idViewer + 'LabelTotalPage',
    idTextCurrentPage = idViewer + 'TextCurrentPage',
    idButtonZoomIn = idViewer + 'ZoomIn',
    idButtonZoomOut = idViewer + 'ZoomOut',
    idSelectZoom = idViewer + 'SelectZoom',
    idOptionZoom1 = idViewer + 'OptionZoom1',
    idOptionZoom2 = idViewer + 'OptionZoom2',
    idOptionZoom3 = idViewer + 'OptionZoom3',
    idOptionZoom4 = idViewer + 'OptionZoom4',
    idOptionZoom5 = idViewer + 'OptionZoom5',
    idOptionZoom6 = idViewer + 'OptionZoom6',
    idOptionZoom7 = idViewer + 'OptionZoom7',
    idOptionZoom8 = idViewer + 'OptionZoom8',
    idOptionZoom9 = idViewer + 'OptionZoom9',
    idTextZoom = idViewer + 'TextZoom',
    idDisplayArea = idViewer + 'DisplayArea',
    idPrintArea = idViewer + 'PrintArea',
    idStatusBar = idViewer + 'StatusBar',
    idStatusIcon = idViewer + 'StatusIcon',
    idPrintInfoIcon = idViewer + 'PrintInfoIcon',
    idPrintNameLabel = idViewer + 'PrintNameLabel',
    idStatusLabel = idViewer + 'StatusLabel',
    idPrintBody = idViewer + 'PrintBody',
    idSvgContainer = svgDocumentid + 'Svgcontainer',
    idSvgPageAreaContainer = svgDocumentid + 'Svgpageareacontainer',
    idSvgPageArea = svgDocumentid + 'Svgpage',
    idSvgTotalPage = svgDocumentid + 'TotalPage',
    idSvgPageNo = svgDocumentid + 'Page',
    idSvgExcelData = svgDocumentid + 'ExcelData',
    idSvgPdfData = svgDocumentid + 'PdfData',
    sViewer = '#' + idViewer,
    sItemBody = '#' + idItemBody,
    sAnimation = '#' + idAnimation,
    sToolBar = '#' + idToolBar,
    sButtonOpenMenu = '#' + idButtonOpenMenu,
    sFileDialog = '#' + idFileDialog,
    sButtonPrintMenu = '#' + idButtonPrintMenu,
    sSubMenuPrint = '#' + idSubMenuPrint,
    sButtonSaveMenu = '#' + idButtonSaveMenu,
    sSubMenuSave = '#' + idSubMenuSave,
    sButtonPrintAll = '#' + idButtonPrintAll,
    sButtonPrintCurrent = '#' + idButtonPrintCurrent,
    sButtonSaveSvgAll = '#' + idButtonSaveSvgAll,
    sButtonSaveSvgCurrent = '#' + idButtonSaveSvgCurrent,
    sButtonSaveExcel = '#' + idButtonSaveExcel,
    sButtonSavePdf = '#' + idButtonSavePdf,
    sButtonFirst = '#' + idButtonFirst,
    sButtonPrev = '#' + idButtonPrev,
    sButtonNext = '#' + idButtonNext,
    sButtonLast = '#' + idButtonLast,
    sLabelTotalPage = '#' + idLabelTotalPage,
    sTextCurrentPage = '#' + idTextCurrentPage,
    sButtonZoomIn = '#' + idButtonZoomIn,
    sButtonZoomOut = '#' + idButtonZoomOut,
    sSelectZoom = '#' + idSelectZoom,
    sOptionZoom1 = '#' + idOptionZoom1,
    sOptionZoom2 = '#' + idOptionZoom2,
    sOptionZoom3 = '#' + idOptionZoom3,
    sOptionZoom4 = '#' + idOptionZoom4,
    sOptionZoom5 = '#' + idOptionZoom5,
    sOptionZoom6 = '#' + idOptionZoom6,
    sOptionZoom7 = '#' + idOptionZoom7,
    sOptionZoom8 = '#' + idOptionZoom8,
    sOptionZoom9 = '#' + idOptionZoom9,
    sTextZoom = '#' + idTextZoom,
    sDisplayArea = '#' + idDisplayArea,
    sPrintArea = '#' + idPrintArea,
    sStatusBar = '#' + idStatusBar,
    sStatusIcon = '#' + idStatusIcon,
    sPrintInfoIcon = '#' + idPrintInfoIcon,
    sPrintNameLabel = '#' + idPrintNameLabel,
    sStatusLabel = '#' + idStatusLabel,
    sPrintBody = '#' + idPrintBody,
    sSvgContainer = '#' + idSvgContainer,
    sSvgPageAreaContainer = '#' + idSvgPageAreaContainer,
    sSvgPageArea = '#' + idSvgPageArea,
    sSvgTotalPage = '#' + idSvgTotalPage,
    sSvgPageNo = '#' + idSvgPageNo,
    sSvgExcelData = '#' + idSvgExcelData,
    sSvgPdfData = '#' + idSvgPdfData,
    classViewerPrintPageOff = idViewer + '_class_printpageoff',
    classViewerPrintPageBreak = idViewer + '_class_printpagebreak',
    $viewerContents = undefined,
    $DisplayAreaContents = undefined,
    readerBinary = new FileReader(),
    readerText = new FileReader(),
    resolveMethod = undefined,
    rejectMethod = undefined,
    timer = 0
  if (
    idViewerContainer == undefined ||
    $(sViewerContainer).length < 1 ||
    parameterStringCheck(idViewerContainer) == false
  ) {
    setError(ErrorResources.ViewerContainer)
    return
  }
  if (this.externalResource != undefined)
    try {
      var resources = this.externalResource()
      resources['ErrorResources'] != undefined &&
        Object.keys(resources['ErrorResources']).forEach(function (keyMessage) {
          resources['ErrorResources'][keyMessage]['message'] != undefined &&
            Object.keys(resources['ErrorResources'][keyMessage]['message']).forEach(function (
              keyLocale
            ) {
              keyLocale = keyLocale.toLowerCase()
              switch (keyLocale) {
                case 'en':
                case 'ja':
                  break
                default:
                  if (ErrorResources[keyMessage] != undefined)
                    if (
                      parameterStringCheck(
                        resources['ErrorResources'][keyMessage]['message'][keyLocale]
                      ) == true
                    )
                      ErrorResources[keyMessage]['message'][keyLocale] =
                        resources['ErrorResources'][keyMessage]['message'][keyLocale]
                  break
              }
            })
        })
      resources['ViewerItemResources'] != undefined &&
        Object.keys(resources['ViewerItemResources']).forEach(function (keyItem) {
          Object.keys(resources['ViewerItemResources'][keyItem]).forEach(function (keyLocale) {
            keyLocale = keyLocale.toLowerCase()
            switch (keyLocale) {
              case 'en':
              case 'ja':
                break
              default:
                if (ViewerItemResources[keyItem] != undefined)
                  if (
                    parameterStringCheck(resources['ViewerItemResources'][keyItem][keyLocale]) ==
                    true
                  )
                    ViewerItemResources[keyItem][keyLocale] =
                      resources['ViewerItemResources'][keyItem][keyLocale]
                break
            }
          })
        })
    } catch (e) {}
  if (locale != undefined && locale != '')
    if (parameterStringCheck(locale) == true) viewerLocale = locale.toLowerCase()
    else viewerLocale = defaultViewerLocale
  svgInlineDocument = getInlineDocument(idViewerContainer)
  svgInlineDocument != undefined && $(sViewerContainer).text('')
  createViewerControl()
  var event = 'click'
  readerBinary.addEventListener('load', function () {
    var bin = new Uint8Array(readerBinary.result)
    // if (bin.length > 3 && bin[0] == 31 && bin[1] == 139 && bin[2] == 8)
    if (bin.length > 3 && bin[0] == 31) {
      bin = decompressgzip(bin)
      //   if (isError()) {
      //     invokeRejectMethod()
      //     return
      //   }
      svgFileType = '.svgz'
      if (setSvgDocument(binaryToString(bin)) == true) invokeResolveMethod()
      else invokeRejectMethod()
    } else readerText.readAsText(svgBlob, binaryToString(bin, true))
  })
  readerText.addEventListener('load', function () {
    var svgText = convertTextToDocument(readerText.result)
    if (isError()) {
      invokeRejectMethod()
      return
    }
    if (setSvgDocument(svgText) == true) invokeResolveMethod()
    else invokeRejectMethod()
  })
  var $parentContents = $viewerContents.contents()
  $parentContents.find(sFileDialog).on('change', function () {
    if (this.files[0] == undefined) return
    clear()
    svgBlob = this.files[0]
    readerBinary.readAsArrayBuffer(svgBlob)
  })
  $parentContents.find(sButtonOpenMenu).on(event, function () {
    hideSubMenu()
    $parentContents.find(sFileDialog).trigger('click')
    return false
  })
  $parentContents.find(sButtonPrintMenu).on(event, function () {
    if (isValidPrintMenu() == false) {
      hideSubMenu()
      return
    }
    if ($parentContents.find(sSubMenuPrint).css('display') == 'none') {
      hideSubMenu()
      setItemDisplayNone(sSubMenuPrint, true)
    } else hideSubMenu()
    return false
  })
  $parentContents.find(sButtonPrintCurrent).on(event, function () {
    hideSubMenu()
    executePrint(viewPage)
    return false
  })
  $parentContents.find(sButtonPrintAll).on(event, function () {
    hideSubMenu()
    executePrint()
    return false
  })
  $parentContents.find(sButtonSaveMenu).on(event, function () {
    if (isValidSaveMenu() == false) {
      hideSubMenu()
      return false
    }
    if ($parentContents.find(sSubMenuSave).css('display') == 'none') {
      hideSubMenu()
      setItemDisplayNone(sSubMenuSave, true)
    } else hideSubMenu()
    return false
  })
  $parentContents.find(sButtonSaveSvgAll).on(event, function () {
    hideSubMenu()
    executeSaveSvgAll()
    return false
  })
  $parentContents.find(sButtonSaveSvgCurrent).on(event, function () {
    hideSubMenu()
    executeSaveSvgCurrent()
    return false
  })
  $parentContents.find(sButtonSaveExcel).on(event, function () {
    hideSubMenu()
    executeSaveExcel()
    return false
  })
  $parentContents.find(sButtonSavePdf).on(event, function () {
    hideSubMenu()
    executeSavePdf()
    return false
  })
  $parentContents.find(sButtonFirst).on(event, function () {
    hideSubMenu()
    if (validPageFirstPrevButton == false) return false
    if (setPageNo(1) == false) return false
    return false
  })
  $parentContents.find(sButtonPrev).on(event, function () {
    hideSubMenu()
    if (validPageFirstPrevButton == false) return false
    if (setPageNo(viewPage - 1) == false) return false
    return false
  })
  $parentContents.find(sTextCurrentPage).on({
    keypress: function (e) {
      hideSubMenu()
      if (validPageFirstPrevButton == false && validPageNextLastButton == false) return false
      if (e.keyCode < 48 || e.keyCode > 57) {
        e.keyCode == 13 && $parentContents.find(sTextCurrentPage).trigger('blur')
        return false
      }
    },
    blur: function () {
      if (validPageFirstPrevButton == false && validPageNextLastButton == false) return false
      var value = $parentContents
        .find(this)
        .val()
        .replace(/[^0-9/]/g, '')
      if (value == '' || setPageNo(parseInt(value)) == false) {
        $parentContents.find(this).val(viewPage)
        return false
      }
      playPage()
      return false
    }
  })
  $parentContents.find(sButtonNext).on(event, function () {
    hideSubMenu()
    if (validPageNextLastButton == false) return false
    if (setPageNo(viewPage + 1) == false) return false
    return false
  })
  $parentContents.find(sButtonLast).on(event, function () {
    hideSubMenu()
    if (validPageNextLastButton == false) return false
    if (setPageNo(totalPage) == false) return false
    return false
  })
  $parentContents.find(sButtonZoomIn).on(event, function () {
    hideSubMenu()
    if (validZoomInButton == false) return false
    if (setPageZoom(pageZoom + 10) == false) return false
    playPage()
    $parentContents.find(sOptionZoom1).text(pageZoom + '%')
    judgmentZoomButtons()
    controlUI()
    return false
  })
  $parentContents.find(sButtonZoomOut).on(event, function () {
    hideSubMenu()
    if (validZoomOutButton == false) return false
    if (setPageZoom(pageZoom - 10) == false) return false
    playPage()
    $parentContents.find(sOptionZoom1).text(pageZoom + '%')
    judgmentZoomButtons()
    controlUI()
    return false
  })
  $parentContents.find(sSelectZoom).on('change', function () {
    hideSubMenu()
    var value = $parentContents.find('option:selected').val()
    if (value == -5) return
    if (value == -4) {
      $parentContents.find(sTextZoom).css('display', '')
      $parentContents.find(sTextZoom).val(pageZoom + '%')
      $parentContents.find(sTextZoom).focus()
      $parentContents.find(sSelectZoom).css('display', 'none')
    } else {
      setPageZoom(parseInt(value))
      playPage()
      $parentContents.find(sOptionZoom1).text($parentContents.find('option:selected').text())
      judgmentZoomButtons()
      controlUI()
    }
    $parentContents.find(sSelectZoom).val('-5')
    return false
  })
  $parentContents.find(sTextZoom).on({
    blur: function () {
      var value = $parentContents
          .find(sTextZoom)
          .val()
          .replace(/[^0-9/]/g, ''),
        prevZoom = pageZoom
      setPageZoom(parseInt(value))
      if (pageZoom != prevZoom) {
        playPage()
        $parentContents.find(sOptionZoom1).text(pageZoom + '%')
        judgmentZoomButtons()
        controlUI()
      }
      $parentContents.find(sSelectZoom).css('display', '')
      $parentContents.find(sSelectZoom).focus()
      $parentContents.find(sTextZoom).css('display', 'none')
      return false
    },
    keypress: function (e) {
      if (e.keyCode < 48 || e.keyCode > 57) {
        e.keyCode == 13 && $parentContents.find(sTextZoom).trigger('blur')
        return false
      }
    }
  })
  $(window).on('resize', function () {
    timer > 0 && clearTimeout(timer)
    timer = setTimeout(function () {
      hideSubMenu()
      getiframeSize()
      if (validPageFirstPrevButton == false && validPageNextLastButton == false) return false
      if (internalPageZoom == -1 || internalPageZoom == -2 || internalPageZoom == -3) {
        setPageZoom(internalPageZoom)
        playPage()
        judgmentZoomButtons()
        controlUI()
      }
    }, 100)
  })
  function adjustFileName(value) {
    if (value == undefined) value = ''
    if (value.indexOf('\\') >= 0) value = value.substring(value.indexOf('\\') + 1)
    if (value.indexOf('/') >= 0) value = value.substring(value.indexOf('/') + 1)
    value = value.replace(/[(\\|/|:|\*|?|\"|<|>|\|)]/g, '')
    value = value.replace("'", '_singlequote_')
    value = value.replace(';', '_semicolon_')
    value = value.replace('&', '_and_')
    if (value == undefined) value = ''
    return value
  }
  function analysisSvgElement(xmlString, startIndex, nodeAttrValues) {
    var length = xmlString.length,
      nodeType = 0,
      nodeName = '',
      exit = false,
      index = startIndex
    try {
      while (index < length) {
        switch (xmlString.charAt(index)) {
          case ' ':
            break
          case '<':
            if (startIndex < index) {
              exit = true
              index--
              break
            }
            var offset = -1
            nodeType = 1
            index++
            while (index < length) {
              var exitsub = false
              switch (xmlString.charAt(index)) {
                case ' ':
                case '>':
                  if (offset >= 0) exitsub = true
                  break
                case '/':
                  if (offset >= 0) exitsub = true
                  else nodeType = 3
                  break
                default:
                  if (offset < 0) offset = index
                  break
              }
              if (exitsub == true) {
                nodeName = xmlString.substring(offset, index)
                nodeAttrValues.push([nodeName, ''])
                break
              }
              index++
            }
            index--
            break
          case '>':
            if (nodeType != 0) exit = true
            break
          case '/':
            if (nodeType != 0) nodeType = 2
            break
          default:
            if (nodeType == 0) break
            var attributes = ['', ''],
              attributeOffset = -1
            while (index < length) {
              var exitsub = false
              switch (xmlString.charAt(index)) {
                case '=':
                case ' ':
                case '>':
                case '/':
                  if (attributeOffset >= 0) exitsub = true
                  break
                default:
                  if (attributeOffset < 0) attributeOffset = index
                  break
              }
              if (exitsub == true) {
                attributes[0] = xmlString.substring(attributeOffset, index)
                break
              }
              index++
            }
            attributeOffset = -1
            var hasValue = false,
              delimiter = ' '
            while (index < length) {
              var exitsub = false
              switch (xmlString.charAt(index)) {
                case '=':
                  hasValue = true
                  break
                case ' ':
                  break
                default:
                  if (hasValue == true)
                    if (xmlString.charAt(index) == "'" || xmlString.charAt(index) == '"') {
                      delimiter = xmlString.charAt(index)
                      index++
                    }
                  exitsub = true
                  break
              }
              if (exitsub == true) break
              index++
            }
            if (hasValue == true) {
              attributeOffset = index
              var escape = false
              while (index < length) {
                var exitsub = false
                if (escape == false) {
                  if (xmlString.charAt(index) == '\\') escape = true
                  else if (xmlString.charAt(index) == '/' || xmlString.charAt(index) == '>') {
                    if (delimiter == ' ') exitsub = true
                  } else if (xmlString.charAt(index) == delimiter) exitsub = true
                } else escape = false
                if (exitsub == true) {
                  attributes[1] = xmlString.substring(attributeOffset, index)
                  if (delimiter != ' ') index++
                  break
                }
                index++
              }
            }
            nodeAttrValues.push(attributes)
            index--
            break
        }
        index++
        if (exit == true) break
      }
      nodeType == 0 &&
        startIndex < index &&
        nodeAttrValues.push(['', xmlString.substring(startIndex, index)])
    } catch (e) {
      index = -1
      nodeAttrValues.length > 0 && nodeAttrValues.splice(0, nodeAttrValues.length)
    }
    return index
  }
  function binaryToString(binary, analysisMode) {
    if (binary == undefined) {
      internalError == ErrorResources.NoError && setError(ErrorResources.UnsupportedDocument)
      return undefined
    }
    var value = '',
      ch,
      codePoint,
      offset = 0,
      len = binary.length,
      charset = ''
    if (charset == '' && len >= 3)
      if (binary[0] == 239 && binary[1] == 187 && binary[2] == 191) {
        charset = 'UTF-8'
        offset = 3
      }
    if (charset == '' && len >= 2)
      if (binary[0] == 254 && binary[1] == 255 && len % 2 == 0) {
        charset = 'UTF-16BE'
        offset = 2
      } else if (binary[0] == 255 && binary[1] == 254 && len % 2 == 0) {
        charset = 'UTF-16LE'
        offset = 2
      } else if (len % 2 == 1) charset = 'UTF-8'
      else {
        charset = 'UTF-8'
        if (binary[0] == 0 && binary[1] == 60) charset = 'UTF-16BE'
        else if (binary[0] == 60 && binary[1] == 0) charset = 'UTF-16LE'
      }
    else charset = 'UTF-8'
    if (analysisMode == true) return charset
    if (charset == 'UTF-16LE')
      while (offset < len) {
        codePoint = binary[offset + 1] << 8
        codePoint |= binary[offset]
        offset += 2
        value += String.fromCharCode(codePoint)
      }
    else if (charset == 'UTF-16BE')
      while (offset < len) {
        codePoint = binary[offset++] << 8
        codePoint |= binary[offset++]
        value += String.fromCharCode(codePoint)
      }
    else {
      var validate = true
      while (offset < len) {
        ch = binary[offset++]
        if (ch <= 127) value += String.fromCharCode(ch)
        else if (ch <= 223) {
          codePoint = (ch & 31) << 6
          if (offset >= binary.length) {
            validate = false
            break
          }
          codePoint += binary[offset++] & 63
          value += String.fromCharCode(codePoint)
        } else if (ch <= 224) {
          if (offset - 1 >= binary.length) {
            validate = false
            break
          }
          codePoint = ((binary[offset++] & 31) << 6) | 2048
          codePoint += binary[offset++] & 63
          value += String.fromCharCode(codePoint)
        } else {
          codePoint = (ch & 15) << 12
          if (offset - 1 >= binary.length) {
            validate = false
            break
          }
          codePoint += (binary[offset++] & 63) << 6
          codePoint += binary[offset++] & 63
          value += String.fromCharCode(codePoint)
        }
      }
      if (validate == false) {
        setError(ErrorResources.UnsupportedDocument)
        value = undefined
      }
    }
    return value
  }
  function clear() {
    viewPage = 0
    totalPage = 0
    setError(ErrorResources.NoError)
    svgBlob = undefined
    svgTextDocument = ''
    svgFileType = '.svg'
    validOpenMenuButton = false
    validPrintButton = false
    validSaveSvgButton = false
    validSaveExcelButton = false
    validSavePdfButton = false
    validPageFirstPrevButton = false
    validPageNextLastButton = false
    validZoomInButton = false
    validZoomOutButton = false
    validZoom = false
    $DisplayAreaContents.find(sSvgPageArea).html('')
    $DisplayAreaContents.find(sSvgContainer).html('')
    var doc = $viewerContents.find(sPrintArea)[0].contentWindow.document
    doc.open()
    doc.write('')
    doc.close()
    $viewerContents.find(sTextCurrentPage).val('0')
    $viewerContents.find(sLabelTotalPage).val('/ 0')
    controlUI()
    displayPrintInfo('', '', '')
    resolveMethod = undefined
    rejectMethod = undefined
  }
  function controlUI() {
    hideSubMenu()
    setItemEnabled(sButtonPrintMenu, isValidPrintMenu())
    setItemEnabled(sButtonSaveMenu, isValidSaveMenu())
    setItemEnabled(sButtonPrintAll, validPrintButton)
    setItemEnabled(sButtonPrintCurrent, validPrintButton)
    setItemEnabled(sButtonSaveSvgAll, validSaveSvgButton)
    setItemEnabled(sButtonSaveSvgCurrent, validSaveSvgButton)
    setItemEnabled(sButtonSaveExcel, validSaveExcelButton)
    setItemEnabled(sButtonSavePdf, validSavePdfButton)
    setItemEnabled(sButtonFirst, validPageFirstPrevButton)
    setItemEnabled(sButtonPrev, validPageFirstPrevButton)
    setItemEnabled(sButtonNext, validPageNextLastButton)
    setItemEnabled(sButtonLast, validPageNextLastButton)
    setItemEnabled(sTextCurrentPage, validPageFirstPrevButton || validPageNextLastButton)
    setItemEnabled(sButtonZoomIn, validZoomInButton)
    setItemEnabled(sButtonZoomOut, validZoomOutButton)
    setItemEnabled(sSelectZoom, validZoom)
    setItemDisplayNone(sToolBar, visibilityToolBar)
    setItemDisplayNone(sButtonOpenMenu, visibilityOpenMenuButton)
    setItemDisplayNone(sButtonSaveMenu, visibilitySaveMenuButton && isValidSaveMenu())
    setItemDisplayNone(sButtonSaveMenu + 'mono', visibilitySaveMenuButton && !isValidSaveMenu())
    setItemDisplayNone(sButtonPrintMenu, visibilityPrintMenuButton && isValidPrintMenu())
    setItemDisplayNone(sButtonPrintMenu + 'mono', visibilityPrintMenuButton && !isValidPrintMenu())
    setItemDisplayNone(sButtonPrintAll, isValidPrintAll())
    setItemDisplayNone(sButtonPrintCurrent, isValidPrintCurrent())
    setItemDisplayNone(sButtonSaveSvgAll, isValidSaveSvgAll())
    setItemDisplayNone(sButtonSaveSvgCurrent, isValidSaveSvgCurrent())
    setItemDisplayNone(sButtonSaveExcel, isValidSaveExcel())
    setItemDisplayNone(sButtonSavePdf, isValidSavePdf())
    setItemDisplayNone(sButtonFirst, visibilityPageFirstButton && validPageFirstPrevButton)
    setItemDisplayNone(
      sButtonFirst + 'mono',
      visibilityPageFirstButton && !validPageFirstPrevButton
    )
    setItemDisplayNone(sButtonPrev, visibilityPagePrevButton && validPageFirstPrevButton)
    setItemDisplayNone(sButtonPrev + 'mono', visibilityPagePrevButton && !validPageFirstPrevButton)
    setItemDisplayNone(sButtonNext, visibilityPageNextButton && validPageNextLastButton)
    setItemDisplayNone(sButtonNext + 'mono', visibilityPageNextButton && !validPageNextLastButton)
    setItemDisplayNone(sButtonLast, visibilityPageLastButton && validPageNextLastButton)
    setItemDisplayNone(sButtonLast + 'mono', visibilityPageLastButton && !validPageNextLastButton)
    setItemDisplayNone(sButtonZoomIn, visibilityZoomButton && validZoomInButton)
    setItemDisplayNone(sButtonZoomIn + 'mono', visibilityZoomButton && !validZoomInButton)
    setItemDisplayNone(sButtonZoomOut, visibilityZoomButton && validZoomOutButton)
    setItemDisplayNone(sButtonZoomOut + 'mono', visibilityZoomButton && !validZoomOutButton)
    setItemDisplayNone(sSelectZoom, visibilityZoomSelect)
    setItemDisplayNone(sStatusBar, visibilityStatusBar)
  }
  function controlUILocale() {
    setItemTitle(sButtonOpenMenu, getResource(ViewerItemResources.sButtonOpenMenu, viewerLocale))
    setItemTitle(sFileDialog, getResource(ViewerItemResources.sFileDialog, viewerLocale))
    setItemTitle(sButtonPrintMenu, getResource(ViewerItemResources.sButtonPrintMenu, viewerLocale))
    setItemTitle(
      sButtonPrintMenu + 'mono',
      getResource(ViewerItemResources.sButtonPrintMenu, viewerLocale)
    )
    setItemTitle(sButtonSaveMenu, getResource(ViewerItemResources.sButtonSaveMenu, viewerLocale))
    setItemTitle(
      sButtonSaveMenu + 'mono',
      getResource(ViewerItemResources.sButtonSaveMenu, viewerLocale)
    )
    setItemTitle(sButtonPrintAll, getResource(ViewerItemResources.sButtonPrintAll, viewerLocale))
    setItemTitle(
      sButtonPrintCurrent,
      getResource(ViewerItemResources.sButtonPrintCurrent, viewerLocale)
    )
    setItemTitle(
      sButtonSaveSvgAll,
      getResource(ViewerItemResources.sButtonSaveSvgAll, viewerLocale)
    )
    setItemTitle(
      sButtonSaveSvgCurrent,
      getResource(ViewerItemResources.sButtonSaveSvgCurrent, viewerLocale)
    )
    setItemTitle(sButtonSaveExcel, getResource(ViewerItemResources.sButtonSaveExcel, viewerLocale))
    setItemTitle(sButtonSavePdf, getResource(ViewerItemResources.sButtonSavePdf, viewerLocale))
    setItemTitle(sButtonFirst, getResource(ViewerItemResources.sButtonFirst, viewerLocale))
    setItemTitle(sButtonFirst + 'mono', getResource(ViewerItemResources.sButtonFirst, viewerLocale))
    setItemTitle(sButtonPrev, getResource(ViewerItemResources.sButtonPrev, viewerLocale))
    setItemTitle(sButtonPrev + 'mono', getResource(ViewerItemResources.sButtonPrev, viewerLocale))
    setItemTitle(sButtonNext, getResource(ViewerItemResources.sButtonNext, viewerLocale))
    setItemTitle(sButtonNext + 'mono', getResource(ViewerItemResources.sButtonNext, viewerLocale))
    setItemTitle(sButtonLast, getResource(ViewerItemResources.sButtonLast, viewerLocale))
    setItemTitle(sButtonLast + 'mono', getResource(ViewerItemResources.sButtonLast, viewerLocale))
    setItemTitle(sLabelTotalPage, getResource(ViewerItemResources.sLabelTotalPage, viewerLocale))
    setItemTitle(sTextCurrentPage, getResource(ViewerItemResources.sTextCurrentPage, viewerLocale))
    setItemTitle(sButtonZoomIn, getResource(ViewerItemResources.sButtonZoomIn, viewerLocale))
    setItemTitle(
      sButtonZoomIn + 'mono',
      getResource(ViewerItemResources.sButtonZoomIn, viewerLocale)
    )
    setItemTitle(sButtonZoomOut, getResource(ViewerItemResources.sButtonZoomOut, viewerLocale))
    setItemTitle(
      sButtonZoomOut + 'mono',
      getResource(ViewerItemResources.sButtonZoomOut, viewerLocale)
    )
    setItemTitle(sSelectZoom, getResource(ViewerItemResources.sSelectZoom, viewerLocale))
    $viewerContents
      .find(sOptionZoom2)
      .text(getResource(ViewerItemResources.sOptionZoom2, viewerLocale))
    $viewerContents
      .find(sOptionZoom3)
      .text(getResource(ViewerItemResources.sOptionZoom3, viewerLocale))
    $viewerContents
      .find(sOptionZoom4)
      .text(getResource(ViewerItemResources.sOptionZoom4, viewerLocale))
    $viewerContents
      .find(sOptionZoom5)
      .text(getResource(ViewerItemResources.sOptionZoom5, viewerLocale))
    $viewerContents
      .find(sOptionZoom6)
      .text(getResource(ViewerItemResources.sOptionZoom6, viewerLocale))
    $viewerContents
      .find(sOptionZoom7)
      .text(getResource(ViewerItemResources.sOptionZoom7, viewerLocale))
    $viewerContents
      .find(sOptionZoom8)
      .text(getResource(ViewerItemResources.sOptionZoom8, viewerLocale))
    $viewerContents
      .find(sOptionZoom9)
      .text(getResource(ViewerItemResources.sOptionZoom9, viewerLocale))
    setItemTitle(sTextZoom, getResource(ViewerItemResources.sTextZoom, viewerLocale))
  }
  function convertTextToDocument(textValue) {
    var svgText = ''
    if (isSvgDocument(textValue) == true) svgText = textValue
    else {
      var bin = decodeBase64(textValue)
      if (bin == undefined || bin.length == 0) {
        setError(ErrorResources.UnsupportedDocument)
        return ''
      }
      if (bin.length > 3 && bin[0] == 31 && bin[1] == 139 && bin[2] == 8) {
        if (svgBlob == undefined) svgBlob = new Blob([bin], { type: 'image/svg+xml' })
        bin = decompressgzip(bin)
        if (isError()) return ''
        svgFileType = '.svgz'
      } else if (bin[0] != 60) {
        setError(ErrorResources.UnsupportedDocument)
        return ''
      }
      svgText = binaryToString(bin)
      if (isSvgDocument(svgText) == false) {
        setError(ErrorResources.UnsupportedDocument)
        return ''
      }
    }
    return svgText
  }
  function createPageText(pageNo, zoomRatio, svgSize) {
    var svgWidth = 0,
      svgHeight = 0,
      viewBoxIndex = 0
    if (zoomRatio == undefined) zoomRatio = 100
    if (svgSize == undefined) svgSize = [0, 0]
    if ($DisplayAreaContents.find(sSvgPageNo + pageNo).length < 1) {
      setError(ErrorResources.UnsupportedDocument)
      return undefined
    }
    if ($DisplayAreaContents.find(sSvgPageNo + pageNo)[0].getAttribute('viewBox') == undefined) {
      setError(ErrorResources.UnsupportedDocument)
      return undefined
    }
    $DisplayAreaContents
      .find(sSvgPageNo + pageNo)[0]
      .getAttribute('viewBox')
      .split(' ')
      .forEach(function (viewBoxValue) {
        viewBoxIndex++
        if (viewBoxIndex == 3) svgWidth = parseFloat(viewBoxValue) * (zoomRatio / 100)
        if (viewBoxIndex == 4) svgHeight = parseFloat(viewBoxValue) * (zoomRatio / 100)
      })
    if (svgWidth == 0) svgWidth = 595.2756
    if (svgHeight == 0) svgHeight = 841.8898
    svgSize[0] = (svgWidth * 4) / 3
    svgSize[1] = (svgHeight * 4) / 3
    return (
      '<svg xmlns="http://www.w3.org/2000/svg" width="' +
      svgWidth +
      'pt" height="' +
      svgHeight +
      'pt" viewBox="' +
      $DisplayAreaContents.find(sSvgPageNo + pageNo)[0].getAttribute('viewBox') +
      '" style="background:#FFFFFF"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="' +
      sSvgPageNo +
      pageNo +
      '"/></svg>'
    )
  }
  function createViewerControl() {
    var imageOpenb64 =
        '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',
      imagePrintMenub64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfZBgwHHQdYNEJlAAAArklEQVRYR+2VUQqAIBBEtRt4qS7Vd5fqUHqEQjDaasyyTYX2QWSQMuzsuNpaO6uKdOFdjeoCoAXGmLDixTkXVhtRAYOewhcP49xDAdIDIqCdGH4VvRhrInYCuKMXg0ZSekAEFBPgG88/R/5TAR9xFHN4D6BScUDPv3UR+R+R6iegM6iA6j2QnAW5tqT2nSxAcMwHWm5EOxYg3iSD7ruqgFiQrAAH2RaU4D/DCKPUArLpf2nQ6+NeAAAAAElFTkSuQmCC',
      imagePrintMenumonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfZBgwHHQdYNEJlAAAArUlEQVRYR+2VUQqAIBBELbqAF/bDA+sRCsNoqzHJNg3cB5VByrCz0w7OuVk1ZIzPZjQXAC3QWscVL977uNpJCrDWxjcejDFQgPSACPhPDL+KXootEQcB3NFLQSMpPSACqgkIjReuM/1UIEQcxRz+B1CpOKDnb/+Bab2foB8i1U/IndG8B7KzoNSW3L7LLEBwzAfqN+I/FiDeJIPuu6uAWJCtAAfFFtSgn2GEUWoBvaV3KW/LZE0AAAAASUVORK5CYII=',
      imagePrintAllb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsIAAA7CARUoSoAAAAEnSURBVFhHzZbtEYIwDIapGzCDu7CBYzgBv5nAMdzAXVwBRqimNnelpG1SUvC5yxE++zZv4mnmebYdQd/3PpOzLIvPymQFmKc/EWBvvyNXxMUf1eFWsJkAgCNiZUH8AlqAZU0RWkU9m7NjI8A83i639+uuHohJiVC3AETHkYMlAHaViz0Y+8Xnjr0WUIDIrAVmfLk4AxUL4pDgLMDd22k43IIqAdJdxoRiWAKoBUdT1zOTHVYCWD0AQsLQRP2HSErVFGjCbkLthRGRgNrGSwENybagFewpaMXhUwBlh0D+ewxx7DR7ABo5bObkFMTAVOCLYQlrCL9TJQCBD8TXUlDPwrXTe2BTASklW0r3VwKkgGCJBdSfEjULYAEqSpxeASfA583ZCui6D2pGDEVq/oOrAAAAAElFTkSuQmCC',
      imagePrintCurrentb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsIAAA7CARUoSoAAAAD5SURBVFhH1ZbbEcIgEEXBDqjBXuzGCvy2AruxF1uAEnCWgQxDFtllAZPzk5AHObk3zERba736I0HAGBOHfJxzca+PTUC/PvEQHX+/hq1E4hK3IiQJDhEAeiV2FaRYa+RVYddy6xjyDZRwJEQCGCAlEuBUgCEWkMIVGLYKemFXUFImt6QCrmRJLtgt8NDvOOLx9LffAtS3myZAYWQC518FUsgVSGKvAXWcq4IZCSyvAB4KwFyHqGC5ALx5nuRWAYV0Y4qxl3yeIBBGDUAyNwdggvJYDezaQ3wDrAQwWrW0zpMFMLBaaoAA9qMyTICSwFSBFtMEOOwFlPoCEeX7OIN9yEcAAAAASUVORK5CYII=',
      imageSaveMenub64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfZBhMHNzHwn1wdAAAAkklEQVRYR+2X0QmAIBRFtQ2cofmapvlaQUcwFDV7ISWY9+cekORhcrCrmLbWegVkSU8YZQWMMbHwJ8651Lu4Cez6iEXJ5tfUa1O/m8fL+UJdSkz9BEFIrvT0DEgJeAgpQIFhAmGP59bDp4NoNPWBxAzABV4z0BsqSWtOZiBDAQpQgAJwAfh9YOqvWc1DAAU4A0qdKFNNdkeJMhMAAAAASUVORK5CYII=',
      imageSaveMenumonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfZBhMHNzHwn1wdAAAAj0lEQVRYR+2XUQqAIBBErRt4YT88sB6hUDS3DSnBnJ95IMli8rBRbAshHAbIXp4wrhWw1ubCn8QYS69xE/De56LGOVd6feS7dbyeL9W1xNJPkIT0Si/PgJaAh5ACFJgmkPZ4bSN8OohmIw8kZgAu8JqB0VBpenMyAxUKUIACFIALwO8DS3/NJA8BFOAMGHMC7MBNYVqnQ7gAAAAASUVORK5CYII=',
      imageSaveSvgb64 =
        'iVBORw0KGgoAAAANSUhEUgAAABkAAAAgCAMAAADQQiM0AAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAACJVBMVEVXnPfW//8AAADT///R///I///H///H//+68f+WyvKRyPGNxvCLxfCLxfCLxfCLxfCNxvCRyPGYzPKm2PaZz/Wn3f+Vz/ii2/////+NyfWd1fzU//+LxfKa0vrE+P+MxvKa0vrE9/+NxvKb0vq47P+SyfOb0Pev4v2azfL////////////////E4viTyfGazvJ+v++SyfGSyfGQyPGQyPGSyfGXzPKZzPKPx/GUyfGTyfHC4PfT6fnO5/nN5vnN5vnP5/nU6fm32/aQyPGRyPHv9/3////Y6/qazfKx2viOx/Hq9PzQ6Pmi0fO02/iNxvHo9PzN5vmczvKx2PXM5vmazPK32vbM5vmZzPK83fbN5vmbzfLH4/jN5vnM5vnw9/3R6PnT6fnS6fnS6PnS6PnS6PnU6frc7fvJ5PiTyfHo9Pzu9/2RyPHo9Pzq9PyOx/Ho9PzU6fq93vfA3/fA4PfA4PfU6fno9Pzo9Pzr9fzf7/vh8Pvh8Pvh8Pvh8Pvr9fzo9Pz3+/7x+P3z+f3z+f3z+f3x+P33+/7P5/m22va43Pa53Pa53Pa43PbO5/n6/f72+v73+/74+/74+/72+v76/f7+///+///R6Pm63Pa83ve93ve93ve83vfR6Pnv9/3l8vzn8/zn8/zn8/zn8/zl8vzv9/2Ox/Hp9PyQyPHu9v2TyfHU6fnt9v3n8/zm8/zm8/yVyvGSyfGQx/GNxvGNxvCNxvBkh/DkAAAAOnRSTlMAAAAAAAAAAADX19fX19fX19jLSNtH4lAB51kC62ID72sF8nUH9X0K/fj4+Pj69pX9+Pj4+Pj4+f78f+sM6gAAAAFiS0dEGJtphR4AAAAJcEhZcwAACxEAAAsRAX9kX5EAAAAHdElNRQfgBQISJAq25ol/AAABYUlEQVQoz2Pg5OLm4eUDA15+AUEhYQZGJjBgsLK2sbWzBwM7B0cnZxFRJmaIjIurGxJw9/AUE5dgAct4eSPL+Pi6+UlKSbOCZPwDkGUCg9zcgmVk5dgwZEJCgUSYvIIiO7pMeASIjFRSVuFAk4mKBlMxqmrqaDKxGppa2traOrp6+mgycQaGRsYmpmbmFpZoMvEJiUnJKalp6RmZDP5ZbthAdg6Dfy5Wmbx8Bv8CN7fCouKSUhgoKS4qc3Mr92fwr3Bzq6yqrqmFgZq6qno3twqgTANW03LxyuA2DbcLcnGahlemsam5pRUGWprb2iEyQHs6Oru6e2Cgu7ezz82tAKKnf8LESZNhYNLEKVOJsMdtGorodIRPZ8ycNXsODMyeO3MexKdAmfkLFi5aDAOLlixdBpZZvgKrPSuWM6xchVVm1UqG1WvWrlu/ARWsX7d2zWqGjZs2b9m6DRVs3bJ500YAgpETtUUF4EEAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTctMDYtMDdUMTU6MDE6NTYrMDk6MDBGX99mAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE2LTA1LTAyVDE4OjM2OjEwKzA5OjAwIq1+YwAAAABJRU5ErkJggg==',
      imageSaveExcelb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfZBhMHNzHwn1wdAAAA0klEQVRYR+2XCw6DIAyGcTfgXF5nx9h1di04gkuTkrHadhaRhmVfQiw+4Lcv45JS2oIjNzy64S7gIwQxRrT6kXNGi2cnYLmvOHuzPZ5oydTPwf1lDrYm4vIQgBDNs0NyQBMxLAklEUOrgBPhXoa/IwDKrQwLh/pAT2hf+OeAGAJrLL9Rr9scAlikDIp2TcMkoPZKvVFtWz03XxJSL5x5e6DJA9xGLZsD84WgN00CuFLjzh3BLIAmHU1KK3OFQCq5M15w/xZc/mPCIQrwYM4+0I8QXoz5dY0lrk8DAAAAAElFTkSuQmCC',
      imageSavePdfb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfZBhMHNzHwn1wdAAAAzElEQVRYR+2UjQ2EIAyFwQ1YyqFvKBhB04TmEKE/HkcTw5cYAUEefS0+xng4Q7b8NsNcwMWCEEJujSOllFttbgI+3ufel/3g06RcB/OxD21KxN8tACFUZKfkACViWhL2REytgpYI8zJ8jwAoN3w0iO6BkdT3wsqBrgVaLznK/y4LSlgL6qrQjgPwbZgFrQ2A3jiHWACesIYax4dCLEB7QpgvWaO2gDuRFpUFms2l89URqHmafMjPApCn1qyr+BaBGZQRuAiwwNwCYwHOne54hiXsx2DTAAAAAElFTkSuQmCC',
      separatorb64 =
        'Qk2OAQAAAAAAADYAAAAoAAAAAgAAACsAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAA7u7u////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb29////AAC9vb3///8AAL29vf///wAAvb297u7uAAA=',
      imagePageFirstb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAADUSURBVFhH7ZfhCcMgEIVNN3CGzpdpOl9X0BESXomh+aF3p/dqof1AQsLF96EHJktKaQsTuR3XaVwEYozn+BTnFiB0eTxfD8G23kPO+bjj8V1bMIMhAUu/1Gq7BUrPYEgSrdougTKhBqnWLOAZDkwC3uFALcAIByoBVjgQBZjhoCnADgemJmTwF2gK4DjGsazBUvuOuAJsCdUWMCXUPcCSMDUhQ8IkALwlzALAU2LoqxjvAKkO1Gq7VqCAyTThoFY7JODBdIHLz2nZJ6Bd2lF+/e84hB2l949SJyq24gAAAABJRU5ErkJggg==',
      imagePageFirstmonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAADPSURBVFhH7ZdRCsMgEERtb+CF/fDAeoSWKTE0H7q7ulML7QMJCRvnoQsmt1LKI2zkfly3cRGIMZ7jU5xbgNCc8+shSCmFWutxx+O7tmAHSwKWfunVTgu0nsGQJEa1UwJtQg1SrVnAMxyYBLzDgVqAEQ5UAqxwIAoww8FQgB0OTE3I4C8wFMBxjGNZg6X2HXEF2BKqLWBKqHuAJWFqQoaESQB4S5gFgKfE0lcx3gFSHejVTq1AA5NpwkGvdknAg+0Cl5/Ttk9Au7Sr/PrfcQhPe22Ppn2zNssAAAAASUVORK5CYII=',
      imagePagePrevb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAC0SURBVFhH7ZfBDYAgEATBDqjB+qzG+mwBStCccdWHgh638SGTEMJrBzguwccYZ/ch3TZ/RhNoAlSBEMI+7qA8QwT6cVpnYR56l1LaVgemJ4DdSvA5PIeJgCYYVAnUBAOVgEUweCVgGQweCTCCQVGAFQyyAghnoipCS7IC0rmkgzEpngAkWCKPrkAkWCKvaoAhoipCSxGVALAQqRIANSImAkAjQv2YSCcFInZF+xk1gb8LOLcAWeBv+j4MmhAAAAAASUVORK5CYII=',
      imagePagePrevmonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAACvSURBVFhH7ZdBDoAgDATRH/BhDjwYnqCpYdWDopRuPMgkhHDaAUoTppTS4j5kLvNnDIEhQBXw3u/jDsozRGCMcZuFEILLOZfVgekJYLcSfA6vYSKgCQZdAj3BQCVgEQyaBCyDwSsBRjB4FGAFg6oAwpmoitCSqoB0LulgTB5PABIskVdXIBIskaYaYIioitBSRCUALES6BECPiIkA0IhQPybSSYGIXTF+RkPg7wLOrTncb/qUjcIZAAAAAElFTkSuQmCC',
      imagePageNextb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAC3SURBVFhH7ZfLDcQgDESddEANW1+qSX3bApSQlaNMxGFRHDxWDuFJyOI0T3yMmHLOmzzIfNTHGAJDoCmQUjpHJH+voYZO6/eYiWzLZ6+llL0yMW2ByuiIWJFbZyBCpOsQMkVct4Ah4hIAHhGKAOgRoQqAWuSKEAFgkQgVsBAqoB30qnuGCGiwJVyhCtTB1neDItATDFwCnmDQJcAIBrcEmMHAJBARDJofk7qDsUNrxs9oCLxdQOQHhnVv+neU8FUAAAAASUVORK5CYII=',
      imagePageNextmonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAACySURBVFhH7ZdNCsQgDIUzvYEXduGB9QgzpPQVF5Wm5oUuxg8kuHof/kT81Fq/8iLbUV9jCSyBoUBK6RyRXF5DDS2lHDORnPNeW2t7ZWLaApXREbEij85AhMjUIWSKuG4BQ8QlADwiFAEwI0IVAL3IHSECwCIRKmAhVEA76F33DBHQYEu4QhXog63vBkVgJhi4BDzBYEqAEQweCTCDgUkgIhgMPyZ9B2OH9qyf0RL4dwGRH2Zxb/obYHfvAAAAAElFTkSuQmCC',
      imagePageLastb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAADYSURBVFhH7ZdhDsIgDEY7b8AZPJ+n8XxeAY4w85lharDQRlp+zJeQbVlD31YGY8s577SQy3FcRphASundOCElQNLt/jiuiPbblUopr/PzlECiEfhWJwlLrMSHQK0V2qhjS2wPsQSWjn+R6I6BCInhIPSWGAoATwmVAPCSUAsADwmTAJgtYRaYzV/ALMCX0hGaWJPA7ORALeCRHKgEvJKDoYBnctAV8E4ORIGI5KD5K65Tp6ZDbSziMC1XuHDzBnBD+zSWWAnVV+DJcoGwzSlflnnZzr47JnoCk7uPUpgRjCsAAAAASUVORK5CYII=',
      imagePageLastmonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAADTSURBVFhH7ZdRDoMgDIbrbsCFeeDAcIQt/yJLF1ZoI4UH9yVEjQ39tAhy5JyftJHHedzGMoEQwqdxlpQASVNK5xVRjJFKKe/z+5RAohH4VScJS6zEl0CtFdqoY0tsD7EElo6vSHTHwAqJ4SD0lhgKAE8JlQDwklALAA8JkwCYLWEWmM1fwCzAl9IRmliTwOzkQC3gkRyoBLySg6GAZ3LQFfBODkSBFclB81dcp05Nh9pYxGFarnDh5g3ghvZpLLESqq/Ak+0CyzanfFnmZbv77pjoBXehj6aih8IUAAAAAElFTkSuQmCC',
      imageZoomInb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfdCxYHHBsJix43AAABMElEQVRYR+2WwQ2DMAxFk27AcEzQUyfqqROwG4xA9VEcOa6dxAXaC09CTQ/wH85v1DjP8xr+iEtgGIa0KlmWJa38NAV46BTTQjCyJ3hlTAEKtkItSKZXRBVAuDdYApEeiVv6zBwRDvAMqzOcYgKtcL7XnNY9tUl8TKBFnMprL1ngqNFLWlvhnsDR/F1gK6E2fqtwct/XMS0E2vO0MlYFvi0ZpHoFrg5cJcxHcc9BpBVTK5zECgdXB7IARmTt+x5q4wfuCWDP+bWX4v8A6CljL3j7e3yG1/rYvld/BZwjJCicAxEpoQoASACvCPVIhhNSwhQgSARYMry89HDc1yPRFOBwGY62tzUBQBIuAS89EqceRHhDhGjQBE4/CTUJCgc/OYq5BA8Hp3ZAgk7w8BBCeANqJ+BmpQmFagAAAABJRU5ErkJggg==',
      imageZoomInmonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfdCxYHHBsJix43AAABKklEQVRYR+2WQQ6DMAwE06of4MMceDA8odVWcbSkdmILUi6MhMgB4sE2hse6ru90ISGBaZryas+2bXkVpyvAQZdlyas98zznVVzGFJDAVlALkfGKqAIIHg1cAxGPxDOfC2cEB9jD6hlml4FecK4107unlYmfDPRAMD6OUgTOSn0N9myVIpyBs7lc4NuEWvq9DRe5TmvGVz6reHpCu8aS0rh74HKBZg9otfQ2oZcyij2DCME0Ac991ji+e6AIIEVH66nRSj8IZwAb8nGUnz+iM7+KEMReIqplYugvmfbG1BKqAJBveFREnta6r5YwBQQRAa1NBdm8lUWW6AowLMNote2VUSRCAlE8EkMHEZ6Qy8NIBoZPQk1CgoO/jGKW4OBgaA/UoCc4eEopfQB86ONMfyakywAAAABJRU5ErkJggg==',
      imageZoomOutb64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfdCxYHGzWaHIU/AAABFElEQVRYR+2WQRKCMAxFW2/Qw3ECV57IlSfgbnAEnM80nVASaLQFFrwZx7ow/5GmVT8Mw+ROxCQQQoirJeM4xpWdXQEe2vu4yOhYBauMKkDBWqgGyZSKiAIItwbnQKRE4hHfEzXCAWpoM8NZCNQKJ0okVh04miRQ++mJvS5cpwNnMR9Dqf38cvkFqZ50LDcFfB8/GJm6coF7Bu4hTD9GrS4ioIWDewaSAFr0775LbLUfXGsLancBtZ7+PQ84XhJN/5IhnPOZXqvtEAUAGVtFqIN5OJFLqAIEb50mw7eNiuN7JRK7AhxtH/O2gi0BQBImASslEk2PIZ4QIRLUgeb3gCRB4eCQi4hL8HDQdAZyMBM83DnnvjViwmoXQad8AAAAAElFTkSuQmCC',
      imageZoomOutmonob64 =
        'iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfdCxYHGzWaHIU/AAABB0lEQVRYR+2WQRKDIAxFaacX8MIuPDAcoZ3fIUygiRAL6oK3kU3J8ydgH977t7sQk8CyLHGVE0KIKztVAV5027a4ylnXNa7sMqoAFdaKapBMq4gogOLWwiUQaZF4xmeiR3GAPbSZ4WQCvYoTLRI/CZxNEuj99kQthfskcBXfYyjFzy+XI0j7ScfyFZ8iR2fCIj9nYA5h+hiNuoiAVhzMGUgCiOjfvkvsxQ/u1YLeKWAvDDYGXPsiDv1L1nIURQFAxlYRSlD7XSmhChA8ur1NCdp8L0UuURXgaH0sYwW1NpKEScBKi8TQY4g35O3hUALD7wFJgoqDUy4iLsGLg6EzUIKZ4MWdc+4D8fXGodmE6CUAAAAASUVORK5CYII=',
      statusErrorb64 =
        'iVBORw0KGgoAAAANSUhEUgAAAA8AAAAQCAMAAAD+iNU2AAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAACeVBMVEXmcpLuS3cAAADuS3fmcpLwepr8WYX8WYXweprze5v3VID3VIDze5vtfJvkTXPtfZvKADLqkKrGBybcADrSADTQAC/dADzkADvRADHQAC3kADzXAC/GACnHACvXADDwX4Xvobbtla3wX4X5WIP/tMz/tc75WIPuSnb/2+b/3ejuSnb////EACzPADLTADjPADPVADTkAD3kAD3VADTRADPnAD7nAD7SADPKADHdADzdADvKADHbY4PbZYXaX4DaX4DbZYXbY4PcaYjcaYjeYYPeYYPcaYjda4rHDkDeaonhYoXhYoXeaonHDkG/ACXGCDzeaonhYoXhYoXeaonGBzvAACfEACjHCDzeaondYILdYILeaonHBzvEACrHACnHBzvcaIfaYIHcaIfHBjrHACvDACTEADXcaIjEADTDACa6ABPLHEzKGkq7ABXebozebozdbYvdbYvfY4XdbYzGCDvdbYzfZIXgXYHdaIjEADW+ACLEAjbdaIjgXoHcWHzdZobGATbDACnCACjGAzfdZobcWHzZWnzcZobFATbHACvHACnGAjfcZobZW33aYYLFADXHACvHACnGAjbaXX/FBTrFBDnFACvEACnFBTrPMFvFBjrCAC3CAC7CAC/CAC7CAC7BACzeb43eb43YVHjfc5Dfc5DYVHjYVnnfc5Dfc5DYVnrYVXnfc5Dfc5DYVXnXU3fecpDecpDXU3fVSnDdbIvdbIvVS3DcaYndbYvcaoneco/cZobeco/fdpPWTHHWTHLfdpPfc5DWTXLWTHLfc5Deco/WS3HWS3Heco/eco/VSnDVSnDeco/fdpLVSnDVSnDfdZLPL1v///8ofgbNAAAAoXRSTlMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABIuTo6uUi+zTQ0zbvC0TY20b9K19M5ONPiWzzX1Ts71eJMOtXVbtXgSjjS/d5HNdrjREPg40RH3vveR0rg1mTI4EpM4tU7LcjiTFvi0zkrxuJbv9E2KcPFus00J7/+uEi5OiyhONhJ6/EAAAABYktHRCskueQIAAAACXBIWXMAAAsRAAALEQF/ZF+RAAAAB3RJTUUH4AcTEhM0deVXegAAAQRJREFUCNdjsLG1Y2BkAgFmFnsHRwanhc4urGxALjuHq9sidwaPxUs8vTi5mLh5vH2WLvNl8PNfviIgkJePPyh45aqQUAaBsPDVayIiBaOi166LiRViEBaJi1+/ISExaeOm5BRRMQYmcYnUtM1b0rduy8iUlGJiYGKSlsnK3r5jZ06urBwTiC+vkJe/a/eegkJFJRBfWaWoeO++kv0HSstU1ZgY1DXKKw4eqqyqPnykplZTi0G7rv7osYZGnabm4ydaWrUZ2tpPnuro1NXT7+o+faanl6Hv7Ln+CQaGTEbGEyedvzCZYcrFqdNMTIH+MTOfPmPmLIbZc+ZaWIL9a2U9b/4CAAdQVh8Yq13zAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE3LTA2LTA3VDE1OjAyOjE3KzA5OjAwj1VhKwAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxNi0wNy0xOVQxODoxOTo1MiswOTowMDHWZfMAAAAASUVORK5CYII=',
      viewerHtml = ''
    viewerHtml += '<iframe id="' + idViewer + '" style="width:100%;height:100%;border:none;">'
    viewerHtml += '</iframe>'
    $(sViewerContainer).html(viewerHtml)
    var contentsHtml = ''
    contentsHtml += '<!doctype html>'
    contentsHtml += '<html lang="ja"><head>'
    contentsHtml += '    <style type="text/css">'
    contentsHtml += '        @page {  margin: 0; }'
    contentsHtml += '        .commandbutton {'
    contentsHtml += '            vertical-align:middle;'
    contentsHtml += '            border-color:#FFFFFF;'
    contentsHtml += '            border-width:1px;'
    contentsHtml += '            border-style:none;'
    contentsHtml += '            margin:3px 3px;'
    contentsHtml += '        }'
    contentsHtml += '        .commandtext {'
    contentsHtml += '            vertical-align:middle;'
    contentsHtml += '            font-family:Meiryo UI;'
    contentsHtml += '            font-size:15pt;'
    contentsHtml += '            border-style:none;'
    contentsHtml += '            margin:3px 3px;'
    contentsHtml += '        }'
    contentsHtml += '        .floatingmenu {'
    contentsHtml += '            vertical-align:middle;'
    contentsHtml += '            border-color:#999999;'
    contentsHtml += '            border-width: 2px;'
    contentsHtml += '            border-style: ridge;'
    contentsHtml += '            background-color: #eeeeee;'
    contentsHtml += '            position:absolute;'
    contentsHtml += '            top:60px;'
    contentsHtml += '            border-radius:7px;'
    contentsHtml += '        }'
    contentsHtml += '        .floatinganimation {'
    contentsHtml += '            position: absolute;'
    contentsHtml += '            top: 0;'
    contentsHtml += '            left: 0;'
    contentsHtml += '            right: 0;'
    contentsHtml += '            bottom: 0;'
    contentsHtml += '            margin: auto;'
    contentsHtml += '        }'
    contentsHtml += '        .itemsection {'
    contentsHtml += '            border-color:#999999;'
    contentsHtml += '            border-width: 2px;'
    contentsHtml += '            border-style: ridge;'
    contentsHtml += '            background-color: #eeeeee;'
    contentsHtml += '        }'
    contentsHtml += '        :disabled {'
    contentsHtml += '          color: #000000;'
    contentsHtml += '        }'
    contentsHtml += '    </style>'
    contentsHtml += '    </head>'
    contentsHtml += '    <body id="' + idItemBody + '" style="margin:0;padding:0;overflow:hidden">'
    contentsHtml +=
      '        <table class="itemsection" style="width:100vw;height:100vh;border-collapse:collapse;">'
    contentsHtml +=
      '            <tr class="itemsection" id="' +
      idToolBar +
      '" style="height:1px;"><td class="itemsection">'
    contentsHtml += '                <div style="width:100%;padding: 0px 5px;" >'
    contentsHtml += '                    <span>'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonOpenMenu +
      '" title="\u958b\u304f" src="data:image/gif;base64,' +
      imageOpenb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonSaveMenu +
      '" title="\u4fdd\u5b58" src="data:image/gif;base64,' +
      imageSaveMenub64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonSaveMenu +
      'mono" title="\u4fdd\u5b58" src="data:image/gif;base64,' +
      imageSaveMenumonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonPrintMenu +
      '" title="\u5370\u5237" src="data:image/gif;base64,' +
      imagePrintMenub64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonPrintMenu +
      'mono" title="\u5370\u5237" src="data:image/gif;base64,' +
      imagePrintMenumonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" disabled="disabled" src="data:image/gif;base64,' +
      separatorb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonFirst +
      '" title="\u5148\u982d\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePageFirstb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonFirst +
      'mono" title="\u5148\u982d\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePageFirstmonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonPrev +
      '" title="\u524d\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePagePrevb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonPrev +
      'mono" title="\u524d\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePagePrevmonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="text" value="0" id="' +
      idTextCurrentPage +
      '" title="\u73fe\u5728\u30da\u30fc\u30b8" class="commandtext" style="font-size:19pt;height:30px;width:80px;text-align:right">'
    contentsHtml +=
      '                        <input type="text" value="/ 0" id="' +
      idLabelTotalPage +
      '" title="\u7dcf\u30da\u30fc\u30b8\u6570" class="commandtext" style="font-size:19pt;height:30px;width:85px;background-color:#eeeeee;" disabled="disabled">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonNext +
      '" title="\u6b21\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePageNextb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonNext +
      'mono" title="\u6b21\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePageNextmonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonLast +
      '" title="\u6700\u7d42\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePageLastb64 +
      '" class="commandbutton"> '
    contentsHtml +=
      '                        <img id="' +
      idButtonLast +
      'mono" title="\u6700\u7d42\u30da\u30fc\u30b8\u3078" src="data:image/gif;base64,' +
      imagePageLastmonob64 +
      '" class="commandbutton"> '
    contentsHtml +=
      '                        <input type="image" disabled="disabled" src="data:image/gif;base64,' +
      separatorb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonZoomIn +
      '" title="\u62e1\u5927" src="data:image/gif;base64,' +
      imageZoomInb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonZoomIn +
      'mono" id="' +
      idButtonZoomIn +
      'mono" title="\u62e1\u5927" src="data:image/gif;base64,' +
      imageZoomInmonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <input type="image" id="' +
      idButtonZoomOut +
      '" title="\u7e2e\u5c0f" src="data:image/gif;base64,' +
      imageZoomOutb64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <img id="' +
      idButtonZoomOut +
      'mono" title="\u7e2e\u5c0f" src="data:image/gif;base64,' +
      imageZoomOutmonob64 +
      '" class="commandbutton">'
    contentsHtml +=
      '                        <select id="' +
      idSelectZoom +
      '"  class="commandtext" style="height:38px;width:140px">'
    contentsHtml +=
      '                            <option id="' +
      idOptionZoom1 +
      '" value="-5" selected>100%</option>'
    contentsHtml +=
      '                            <option id="' +
      idOptionZoom2 +
      '" value="-4">\u76f4\u63a5\u5165\u529b</option>'
    contentsHtml +=
      '                            <option id="' +
      idOptionZoom3 +
      '" value="-1">\u5168\u3066\u8868\u793a</option>'
    contentsHtml +=
      '                            <option id="' +
      idOptionZoom4 +
      '" value="-2">\u6a2a\u306b\u3042\u308f\u305b\u308b</option>'
    contentsHtml +=
      '                            <option id="' +
      idOptionZoom5 +
      '" value="-3">\u7e26\u306b\u3042\u308f\u305b\u308b</option>'
    contentsHtml +=
      '                            <option id="' + idOptionZoom6 + '" value="50">50%</option>'
    contentsHtml +=
      '                            <option id="' + idOptionZoom7 + '" value="100">100%</option>'
    contentsHtml +=
      '                            <option id="' + idOptionZoom8 + '" value="300">300%</option>'
    contentsHtml +=
      '                            <option id="' + idOptionZoom9 + '" value="600">600%</option>'
    contentsHtml += '                        </select>'
    contentsHtml +=
      '                        <input id="' +
      idTextZoom +
      '" type="text" value="0" class="commandtext" style="height:38px;width:140px;display:none;">'
    contentsHtml += '                    </span>'
    contentsHtml +=
      '                    <div id="' +
      idSubMenuPrint +
      '" class="floatingmenu" style="display:none;">'
    contentsHtml += '                        <span style="padding:7px;">'
    contentsHtml +=
      '                            <input type="image" id="' +
      idButtonPrintAll +
      '" title="\u5168\u30da\u30fc\u30b8" src="data:image/gif;base64,' +
      imagePrintAllb64 +
      '" class="commandbutton"">'
    contentsHtml +=
      '                            <input type="image" id="' +
      idButtonPrintCurrent +
      '" title="\u73fe\u5728\u306e\u30da\u30fc\u30b8" src="data:image/gif;base64,' +
      imagePrintCurrentb64 +
      '" class="commandbutton"">'
    contentsHtml += '                        </span>'
    contentsHtml += '                    </div>'
    contentsHtml +=
      '                    <div id="' +
      idSubMenuSave +
      '"  class="floatingmenu" style="display:none;">'
    contentsHtml += '                        <span style="padding:7px;">'
    contentsHtml +=
      '                            <input type="image" id="' +
      idButtonSaveSvgAll +
      '" title="SVG" src="data:image/gif;base64,' +
      imageSaveSvgb64 +
      '" class="commandbutton"">'
    contentsHtml +=
      '                            <input type="image" id="' +
      idButtonSaveSvgCurrent +
      '" title="SVG(\u3053\u306e\u30da\u30fc\u30b8)" src="data:image/gif;base64,' +
      imageSaveSvgb64 +
      '" class="commandbutton"">'
    contentsHtml +=
      '                            <input type="image" id="' +
      idButtonSaveExcel +
      '" title="Excel" src="data:image/gif;base64,' +
      imageSaveExcelb64 +
      '" class="commandbutton"">'
    contentsHtml +=
      '                            <input type="image" id="' +
      idButtonSavePdf +
      '" title="PDF" src="data:image/gif;base64,' +
      imageSavePdfb64 +
      '" class="commandbutton"">'
    contentsHtml += '                        </span>'
    contentsHtml += '                    </div>'
    contentsHtml +=
      '                    <div style="position:absolute; top:1px; border-radius:1px;visibility:hidden;" >'
    contentsHtml += '                        <input type="file" id="' + idFileDialog + '">'
    contentsHtml += '                    </div>'
    contentsHtml += '                </div>'
    contentsHtml += '            </td></tr>'
    contentsHtml +=
      '            <tr class="itemsection" style="height:100%;"><td class="itemsection"><div style="width:100%;height:100%;">'
    contentsHtml +=
      '                <iframe id="' +
      idPrintArea +
      '" style="position:absolute;opacity:0;overflow:hidden;margin: 0 auto;width:2px;height:2px;" sandbox="allow-same-origin allow-modals">'
    contentsHtml += '                </iframe>'
    contentsHtml +=
      '                <iframe id="' +
      idDisplayArea +
      '" style="width:calc(100% - 2px); height:100%;" sandbox="allow-same-origin allow-modals">'
    contentsHtml += '                </iframe></div>'
    contentsHtml += '            </td></tr>'
    contentsHtml +=
      '            <tr id="' +
      idStatusBar +
      '" class="itemsection" style="height:1px;"><td class="itemsection">'
    contentsHtml += '                <div style="width:100%;" >'
    contentsHtml += '                    <span style="white-space: nowrap;">'
    contentsHtml +=
      '                        <input type="text" value="" id="' +
      idPrintNameLabel +
      '" style="font-size:12pt;height:20px;width:45%;margin:0px 0px;background-color:#eeeeee;border-style:none;" disabled="disabled">'
    contentsHtml +=
      '                        <input type="image" disabled="disabled" src="data:image/gif;base64,' +
      separatorb64 +
      '" class="commandbutton" style="height:20px;">'
    contentsHtml +=
      '                        <img id="' +
      idStatusIcon +
      '" src="data:image/gif;base64,' +
      statusErrorb64 +
      '"  style="vertical-align:middle;border-color:#FFFFFF;border-width:1px;border-style:none;visibility:hidden;height:20px">'
    contentsHtml +=
      '                        <input type="text" value="" id="' +
      idStatusLabel +
      '" style="font-size:12pt;height:20px;width:40%;margin:0px 0px;background-color:#eeeeee;border-style:none;" disabled="disabled">'
    contentsHtml += '                    </span>'
    contentsHtml += '                </div>'
    contentsHtml += '            </td></tr>'
    contentsHtml += '        </table>'
    contentsHtml += '    </body>'
    contentsHtml += '</html>'
    var doc = $(sViewer)[0].contentWindow.document
    doc.open()
    doc.write(contentsHtml)
    doc.close()
    $viewerContents = $(sViewer).contents()
    var previewHtml = ''
    previewHtml += '<!doctype html>'
    previewHtml += '<html lang="ja"><head>'
    previewHtml += '    <style type="text/css">'
    previewHtml += '        @page {  margin: 0mm 0mm 0mm 0mm; }'
    previewHtml += '        .' + classViewerPrintPageOff + ' { display:none; }'
    previewHtml += '        .' + classViewerPrintPageBreak + ' { page-break-before: always; }'
    previewHtml += '        .itemsection {'
    previewHtml += '            border-style: none;'
    previewHtml += '            padding: 0px;'
    previewHtml += '        }'
    previewHtml += '    </style>'
    previewHtml += '    </head>'
    previewHtml += '    <body style="background-color:#999999;margin: 0;padding: 0;">'
    previewHtml +=
      '        <div id="' +
      idSvgContainer +
      '" style="position:absolute;opacity:0;overflow:hidden;margin: 0 auto;width:2px;height:2px;">'
    previewHtml += '        </div>'
    previewHtml +=
      '        <table id="' +
      idSvgPageAreaContainer +
      '" class="itemsection" style="min-width:95vw;min-height:95vh;">'
    previewHtml +=
      '            <tr class="itemsection"><td class="itemsection"></td><td class="itemsection"></td><td class="itemsection"></td></tr>'
    previewHtml +=
      '            <tr class="itemsection"><td class="itemsection"></td><td class="itemsection">'
    previewHtml +=
      '                <div id="' + idSvgPageArea + '" style="overflow:hidden;margin: 0 auto;">'
    previewHtml += '                </div>'
    previewHtml += '            </td><td class="itemsection"></td></tr>'
    previewHtml +=
      '            <tr class="itemsection"><td class="itemsection"></td><td class="itemsection"></td><td class="itemsection"></td></tr>'
    previewHtml += '        </table>'
    previewHtml += '    </body>'
    previewHtml += '</html>'
    doc = $viewerContents.find(sDisplayArea)[0].contentWindow.document
    doc.open()
    doc.write(previewHtml)
    doc.close()
    $DisplayAreaContents = $viewerContents.find(sDisplayArea).contents()
    getiframeSize()
    controlUI()
    controlUILocale()
  }
  function displayPrintInfo(sheetName, printName, orientation) {
    $viewerContents.find(sPrintNameLabel).val('')
    var statustext = ''
    if (sheetName != undefined && sheetName != '') statustext += '  ' + sheetName
    if (printName != undefined && printName != '') {
      statustext += '  [ ' + printName
      statustext += ' : '
      statustext +=
        orientation == '0'
          ? getResource(ViewerItemResources.sPrintPageLandscape, viewerLocale)
          : getResource(ViewerItemResources.sPrintPageportrait, viewerLocale)
      statustext += ' ]'
    }
    $viewerContents.find(sPrintNameLabel).val(statustext)
  }
  function decodeBase64(value) {
    if (value == undefined) return undefined
    var encodeString = value.replace(/[^A-Za-z0-9+/]/g, ''),
      len = encodeString.length
    if (len < 2) return undefined
    for (var bin = new Uint8Array(Math.floor((len * 6) / 8)), offset = 0; offset < len; offset++) {
      var code = encodeString.charCodeAt(offset)
      if (code >= 65 && code <= 90) code -= 65
      else if (code >= 97 && code <= 122) code -= 71
      else if (code >= 48 && code <= 57) code += 4
      else if (code == 43) code = 62
      else if (code == 47) code = 63
      else if (code == 61) break
      else continue
      var binOffset = Math.floor(((offset + 1) * 6) / 8)
      if (((offset + 1) * 6) % 8 == 0) binOffset -= 1
      var shift = 8 * (binOffset + 1) - 6 * (offset + 1)
      bin[binOffset] = bin[binOffset] | ((code << shift) & 255)
      if (shift > 2) bin[binOffset - 1] = bin[binOffset - 1] | (code >> (8 - shift))
    }
    return bin
  }
  function decompressgzip(compressdBinary) {
    try {
      var gunzip = new Zlib.$(compressdBinary)
      return gunzip.g()
    } catch (e) {
      setError(ErrorResources.InternalException)
    }
    return undefined
  }
  function displayAnimation(display) {
    if (display)
      $viewerContents
        .find(sItemBody)
        .prepend(
          '<img id="' +
            idAnimation +
            '" src="data:image/gif;base64,' +
            imageLoadingb64 +
            '" class="floatinganimation">'
        )
    else $viewerContents.find(sAnimation).remove()
  }
  function downloadLocalBlob(blob, filename) {
    if (window.navigator.msSaveBlob) window.navigator.msSaveBlob(blob, filename)
    else {
      var a = document.createElement('a')
      a.href = URL.createObjectURL(blob)
      a.target = '_blank'
      a.download = filename
      a.click()
    }
  }
  function executeSaveSvgAll() {
    if (isValidSaveMenu() == false || validSaveSvgButton == false)
      return setError(ErrorResources.IllegalOperation)
    var blob = svgBlob
    if (blob == undefined) blob = new Blob([svgTextDocument], { type: 'image/svg+xml' })
    var dt = new Date(),
      y = dt.getFullYear(),
      m = ('00' + (dt.getMonth() + 1)).slice(-2),
      d = ('00' + dt.getDate()).slice(-2),
      h = ('00' + dt.getHours()).slice(-2),
      mm = ('00' + dt.getMinutes()).slice(-2),
      s = ('00' + dt.getSeconds()).slice(-2),
      ymdhms = y + '' + m + '' + d + '_' + h + '' + mm,
      fileName = 'document' + ymdhms + svgFileType
    if (saveSvgFileName != '') {
      fileName = saveSvgFileName
      if (fileName.indexOf('.') == -1) fileName += svgFileType
    }
    downloadLocalBlob(blob, fileName)
    return true
  }
  function executeSaveSvgCurrent() {
    if (isValidSaveMenu() == false || validSaveSvgButton == false)
      return setError(ErrorResources.IllegalOperation)
    var currentSvgData = createPageText(viewPage),
      blob = new Blob([currentSvgData], { type: 'image/svg+xml' }),
      dt = new Date(),
      y = dt.getFullYear(),
      m = ('00' + (dt.getMonth() + 1)).slice(-2),
      d = ('00' + dt.getDate()).slice(-2),
      h = ('00' + dt.getHours()).slice(-2),
      mm = ('00' + dt.getMinutes()).slice(-2),
      s = ('00' + dt.getSeconds()).slice(-2),
      ymdhms = y + '' + m + '' + d + '_' + h + '' + mm,
      fileName = 'document' + ymdhms + '.svg'
    if (saveSvgFileName != '') {
      fileName = saveSvgFileName
      if (fileName.indexOf('.') == -1) fileName += '.svg'
    }
    downloadLocalBlob(blob, fileName)
    return true
  }
  function executeSaveExcel() {
    if (validSaveExcelButton == false) return setError(ErrorResources.IllegalOperation)
    var suffix = '.xls',
      excelData = $DisplayAreaContents.find(sSvgExcelData).text()
    if (excelData === void 0 || excelData.length == 0) return setError(ErrorResources.NoExcelData)
    var buffer = decodeBase64(excelData),
      mimeType = 'application/vnd.ms-excel'
    if (buffer[0] != 208 || buffer[1] != 207) {
      suffix += 'x'
      mimeType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
    }
    var blob = new Blob([buffer.buffer], { type: mimeType }),
      dt = new Date(),
      y = dt.getFullYear(),
      m = ('00' + (dt.getMonth() + 1)).slice(-2),
      d = ('00' + dt.getDate()).slice(-2),
      h = ('00' + dt.getHours()).slice(-2),
      mm = ('00' + dt.getMinutes()).slice(-2),
      s = ('00' + dt.getSeconds()).slice(-2),
      ymdhms = y + '' + m + '' + d + '_' + h + '' + mm,
      fileName = 'document' + ymdhms + 'output' + suffix
    if (saveExcelFileName != '') {
      fileName = saveExcelFileName
      if (fileName.indexOf('.') == -1) fileName += suffix
    }
    downloadLocalBlob(blob, fileName)
    return true
  }
  function executeSavePdf() {
    if (validSavePdfButton == false) return setError(ErrorResources.IllegalOperation)
    var pdfData = $DisplayAreaContents.find(sSvgPdfData).text()
    if (pdfData === void 0 || pdfData.length == 0) return setError(ErrorResources.NoPdfData)
    var buffer = decodeBase64(pdfData),
      blob = new Blob([buffer.buffer], { type: 'application/pdf' }),
      dt = new Date(),
      y = dt.getFullYear(),
      m = ('00' + (dt.getMonth() + 1)).slice(-2),
      d = ('00' + dt.getDate()).slice(-2),
      h = ('00' + dt.getHours()).slice(-2),
      mm = ('00' + dt.getMinutes()).slice(-2),
      s = ('00' + dt.getSeconds()).slice(-2),
      ymdhms = y + '' + m + '' + d + '_' + h + '' + mm,
      fileName = 'document' + ymdhms + '.pdf'
    if (savePdfFileName != '') {
      fileName = savePdfFileName
      if (fileName.indexOf('.') == -1) fileName += '.pdf'
    }
    downloadLocalBlob(blob, fileName)
    return true
  }
  function executePrint(pageNo) {
    if (validPrintButton == false) return false
    try {
      var pageNoArray = undefined
      if (pageNo == undefined) pageNoArray = ['1-' + totalPage]
      else {
        pageNo += 'A'
        pageNo = pageNo.replace(/[^0-9,\-/]/g, '')
        if (pageNo == '') pageNoArray = ['1-' + totalPage]
        else {
          pageNoArray = pageNo.split(',')
          for (
            var arraysize = pageNoArray.length, isvalid = false, arrayindex = 0;
            arrayindex < arraysize;
            arrayindex++
          ) {
            var fromtoArray = pageNoArray[arrayindex].split('-'),
              from = 1,
              to = totalPage
            if (isNaN(parseInt(fromtoArray[0])) == false) {
              from = parseInt(fromtoArray[0])
              if (from <= 0) from = 1
              if (from > totalPage) from = totalPage
            }
            if (fromtoArray.length < 2) to = from
            else if (isNaN(parseInt(fromtoArray[1])) == false) {
              var to = parseInt(fromtoArray[1])
              if (to <= 0) to = 1
              if (to > totalPage) to = totalPage
              if (from > to) to = from
            }
            pageNoArray[arrayindex] = from + '-' + to
            isvalid = true
          }
          if (isvalid == false) return setError(ErrorResources.IllegalOperation)
        }
      }
      for (
        var printPages = '',
          firstPage = true,
          pageNoArrayLength = pageNoArray.length,
          overflowCorrection = 4,
          pageNoArrayIndex = 0;
        pageNoArrayIndex < pageNoArrayLength;
        pageNoArrayIndex++
      )
        for (
          var fromtoArray = pageNoArray[pageNoArrayIndex].split('-'),
            from = parseInt(fromtoArray[0]),
            to = parseInt(fromtoArray[1]);
          from <= to;
          from++
        ) {
          var svgSize = [0, 0],
            svgPage = createPageText(from, 100, svgSize)
          printPages +=
            '<div id="' +
            idPrintBody +
            '-' +
            pageNoArrayIndex +
            '-' +
            from +
            '" style="width:' +
            parseInt(svgSize[0] - overflowCorrection) +
            'px;height:' +
            parseInt(svgSize[1] - overflowCorrection) +
            'px;overflow:hidden;" '
          if (firstPage == false) printPages += ' class="' + classViewerPrintPageBreak + '" '
          printPages += '>'
          printPages += svgPage
          printPages += '</div> '
          firstPage = false
        }
      var browserType = getBrowserType()
      if (browserType == 'ie') {
        $DisplayAreaContents.find(sSvgPageAreaContainer).addClass(classViewerPrintPageOff)
        $DisplayAreaContents.find('body').append(printPages)
        $viewerContents.find(sDisplayArea)[0].contentWindow.focus()
        $viewerContents.find(sDisplayArea)[0].contentWindow.print()
        $DisplayAreaContents.find('[id^="' + idPrintBody + '"]').remove()
        $DisplayAreaContents.find(sSvgPageAreaContainer).removeClass(classViewerPrintPageOff)
        return true
      }
      var printPageText = ''
      printPageText += '<!doctype html>'
      printPageText += '<html lang="ja"><head>'
      printPageText += '    <style type="text/css">'
      if (applyPageSize == true) {
        var paperName = $DisplayAreaContents.find(sSvgPageNo + '1')[0].getAttribute('papername')
        if (paperName == undefined || paperName == '')
          if (parseInt(svgSize[0]) == 793 && parseInt(svgSize[1]) == 1122) paperName = 'A4'
        var orientation = $DisplayAreaContents
            .find(sSvgPageNo + '1')[0]
            .getAttribute('orientation'),
          orientationName = orientation == '0' ? 'landscape' : 'portrait'
        printPageText +=
          '        @page {  size: ' +
          paperName +
          ' ' +
          orientationName +
          ';margin: 0mm 0mm 0mm 0mm; }'
      } else printPageText += '        @page {  margin: 0mm 0mm 0mm 0mm; }'
      printPageText += '        .' + classViewerPrintPageBreak + ' { page-break-before: always; }'
      printPageText += '    </style>'
      printPageText += '    </head>'
      printPageText += '    <body style="background-color:#FFFFFF;margin: 0;padding: 0;">'
      printPageText +=
        '        <div id="' +
        idSvgContainer +
        '" style="position:absolute;opacity:0;overflow:hidden;margin: 0 auto;width:2px;height:2px;">'
      printPageText += $DisplayAreaContents.find(sSvgContainer).html()
      printPageText += '        </div>'
      printPageText += printPages
      printPageText += '    </body>'
      printPageText += '</html>'
      var doc = $viewerContents.find(sPrintArea)[0].contentWindow.document
      doc.open()
      doc.write(printPageText)
      doc.close()
      $viewerContents.find(sPrintArea)[0].contentWindow.focus()
      $viewerContents.find(sPrintArea)[0].contentWindow.print()
      $viewerContents.find(sDisplayArea)[0].contentWindow.focus()
      return true
    } catch (e) {
      return setError(ErrorResources.InternalException)
    }
  }
  function getBrowserType() {
    var type = 'other',
      agent = window.navigator.userAgent.toLowerCase()
    if (
      agent.indexOf('chrome') !== -1 &&
      agent.indexOf('edge') === -1 &&
      agent.indexOf('opr') === -1
    )
      type = 'chrome'
    else if (agent.indexOf('trident/7') !== -1) type = 'ie'
    else if (agent.indexOf('meie') !== -1) type = 'ie'
    else if (agent.indexOf('firefox') !== -1) type = 'firefox'
    return type
  }
  function getErrorMessage() {
    if (isError() == false) return ''
    if (internalError.message[viewerLocale] == undefined)
      return internalError.message[defaultViewerLocale]
    else return internalError.message[viewerLocale]
  }
  function getiframeSize() {
    iframeHeight =
      $viewerContents
        .find(sDisplayArea)
        .css('height')
        .replace(/[^0-9./]/g, '') * 0.97
    iframeWidth =
      $viewerContents
        .find(sDisplayArea)
        .css('width')
        .replace(/[^0-9./]/g, '') * 0.97
    if (iframeHeight < 100) iframeHeight = 100
    if (iframeWidth < 100) iframeWidth = 100
  }
  function getInlineDocument(documentcontainerId) {
    if (documentcontainerId == undefined || documentcontainerId == '') {
      if (svgInlineDocument == undefined) {
        setError(ErrorResources.Documentnotloaded)
        return undefined
      }
      return svgInlineDocument
    }
    var textValue = '',
      ldocumentcontainerId = '' + documentcontainerId + ''
    if (ldocumentcontainerId.indexOf('#') != 0) ldocumentcontainerId = '#' + ldocumentcontainerId
    if ($(ldocumentcontainerId).length < 1) {
      setError(ErrorResources.NoDocument)
      return undefined
    }
    if ($(ldocumentcontainerId).children().length == 0) textValue = $(ldocumentcontainerId).text()
    else textValue = $(ldocumentcontainerId).html()
    return textValue
  }
  function getResource(resource, key) {
    if (resource[key] == undefined) return resource[defaultViewerLocale]
    else return resource[key]
  }
  function hideSubMenu() {
    setItemDisplayNone(sSubMenuPrint, false)
    setItemDisplayNone(sSubMenuSave, false)
  }
  function invokeResolveMethod() {
    resolveMethod != undefined && resolveMethod()
    resolveMethod = null
    rejectMethod = null
  }
  function invokeRejectMethod() {
    //rejectMethod != undefined && rejectMethod()
    resolveMethod = null
    rejectMethod = null
  }
  function isBooleanValue(value) {
    if (value == undefined) return false
    return typeof value == 'boolean'
  }
  function isExistsFileItem(itemName) {
    return $DisplayAreaContents.find(itemName).length >= 1
  }
  function isError() {
    return internalError != ErrorResources.NoError
  }
  function isSvgDocument(value) {
    if (value == undefined) return false
    var result = false,
      pos = value.indexOf('<'),
      length = value.length
    if (pos >= 0 && length - (pos + 1) >= 3)
      if (value.substring(pos + 1, pos + 4).toLowerCase() == 'svg') result = true
    if (result == false) return false
    var isError = false,
      valiableNodeNames = [
        'a',
        'animate',
        'animatemotion',
        'animatetransform',
        'circle',
        'clippath',
        'color-profile',
        'defs',
        'desc',
        'discard',
        'ellipse',
        'feblend',
        'fecolormatrix',
        'fecomponenttransfer',
        'fecomposite',
        'feconvolvematrix',
        'fediffuselighting',
        'fedisplacementmap',
        'fedistantlight',
        'fedropshadow',
        'feflood',
        'fefunca',
        'fefuncb',
        'fefuncg',
        'fefuncr',
        'fegaussianblur',
        'feimage',
        'femerge',
        'femergenode',
        'femorphology',
        'feoffset',
        'fepointlight',
        'fespecularlighting',
        'fespotlight',
        'fetile',
        'feturbulence',
        'filter',
        'foreignobject',
        'g',
        'hatch',
        'hatchpath',
        'image',
        'line',
        'lineargradient',
        'marker',
        'mask',
        'mesh',
        'meshgradient',
        'meshpatch',
        'meshrow',
        'metadata',
        'mpath',
        'path',
        'pattern',
        'polygon',
        'polyline',
        'radialgradient',
        'rect',
        'set',
        'solidcolor',
        'stop',
        'style',
        'svg',
        'switch',
        'symbol',
        'text',
        'textpath',
        'title',
        'tspan',
        'unknown',
        'use',
        'view'
      ],
      length = value.length,
      index = 0,
      prevIndex = -1,
      prefixText = '',
      suffixText = '',
      isTopSvgElment = false,
      nodeName = ''
    try {
      while (index < length) {
        var nodeAttrValues = []
        index = analysisSvgElement(value, index, nodeAttrValues)
        if (prevIndex >= index) {
          isError = true
          break
        }
        if (nodeAttrValues.length == 0) {
          isError = true
          break
        }
        prevIndex = index
        if (nodeAttrValues[0][0] != '') {
          nodeName = nodeAttrValues[0][0].toLowerCase()
          if (isTopSvgElment == false) {
            if (nodeName != 'svg') {
              isError = true
              break
            }
            isTopSvgElment = true
          }
          suffixText = ''
          if (valiableNodeNames.indexOf(nodeName) < 0) isError = true
          if (nodeAttrValues.length > 1)
            for (
              var itemCount = nodeAttrValues.length, attributeIndex = 1;
              attributeIndex < itemCount;
              attributeIndex++
            ) {
              var attributeName = nodeAttrValues[attributeIndex][0].toLowerCase(),
                attributeValue = (nodeAttrValues[attributeIndex][1] + '').toLowerCase()
              if (startsWith(attributeName, 'on') == true) isError = true
              if (endsWith(attributeName, 'pointer-events') == true) isError = true
              if (attributeName == 'src') isError = true
              if (endsWith(attributeName, 'href') == true)
                if (nodeName == 'use') {
                  if (attributeValue.replace(/[a-zA-Z0-9]/g, '') != '#') isError = true
                } else if (nodeName == 'image') {
                  if (startsWith(attributeValue, 'data:image/') == false) isError = true
                } else isError = true
            }
        } else {
          if (isTopSvgElment == false) prefixText = nodeAttrValues[0][1] + ''
          suffixText = nodeAttrValues[0][1] + ''
        }
        if (isError == true) break
      }
      if (isError == true) return false
      else {
        if (isTopSvgElment == false) return false
        if (nodeName != 'svg') return false
        if (prefixText.replace(/[ \t\r\n]/g, '') != '') return false
        if (suffixText.replace(/[ \t\r\n]/g, '') != '') return false
      }
    } catch (e) {
      return false
    }
    return true
  }
  function startsWith(source, target) {
    if (source == undefined) return false
    if (target == undefined) return false
    if (source.length < target.length) return false
    var reg = new RegExp('^' + target)
    if (source.match(reg)) return true
    else return false
  }
  function endsWith(source, target) {
    if (source == undefined) return false
    if (target == undefined) return false
    if (source.length < target.length) return false
    var reg = new RegExp('^.*' + target + '$')
    if (source.match(reg)) return true
    else return false
  }
  function isValidSaveMenu() {
    return isValidSaveSvgAll() || isValidSaveSvgCurrent() || isValidSaveExcel() || isValidSavePdf()
  }
  function isValidSaveSvgAll() {
    return visibilitySaveSvgAllButton && validSaveSvgButton
  }
  function isValidSaveSvgCurrent() {
    return visibilitySaveSvgCurrentButton && validSaveSvgButton
  }
  function isValidSaveExcel() {
    return visibilitySaveExcelButton && validSaveExcelButton
  }
  function isValidSavePdf() {
    return visibilitySavePdfButton && validSavePdfButton
  }
  function isValidPrintMenu() {
    return isValidPrintAll() || isValidPrintCurrent()
  }
  function isValidPrintAll() {
    return visibilityPrintAllButton && validPrintButton
  }
  function isValidPrintCurrent() {
    return visibilityPrintCurrentButton && validPrintButton
  }
  function judgmentPageButtons() {
    if (viewPage <= 1) validPageFirstPrevButton = false
    else validPageFirstPrevButton = true
    if (viewPage >= totalPage) validPageNextLastButton = false
    else validPageNextLastButton = true
  }
  function judgmentZoomButtons() {
    if (pageZoom <= 20) validZoomOutButton = false
    else validZoomOutButton = true
    if (pageZoom >= 600) validZoomInButton = false
    else validZoomInButton = true
  }
  function parameterStringCheck(parameterString) {
    if (parameterString == undefined) return true
    var regex = /[\u0022\u0026\u0027\u003c\u003e]/
    return !regex.test(parameterString)
  }
  function playPage() {
    setError(ErrorResources.NoError)
    var svgSize = [0, 0]
    ;(internalPageZoom == -1 || internalPageZoom == -2 || internalPageZoom == -3) &&
      setPageZoom(internalPageZoom)
    var svgPage = createPageText(viewPage, pageZoom, svgSize)
    if (isError()) return false
    try {
      $DisplayAreaContents.find(sSvgPageArea).html(svgPage)
      $DisplayAreaContents.find(sSvgPageArea).css('width', svgSize[0])
      $DisplayAreaContents.find(sSvgPageArea).css('height', svgSize[1])
      $viewerContents.find(sTextCurrentPage).val(viewPage)
      var paperName = $DisplayAreaContents.find(sSvgPageNo + viewPage)[0].getAttribute('papername')
      if (paperName == undefined || paperName == '')
        if (parseInt(svgSize[0]) == 793 && parseInt(svgSize[1]) == 1122) paperName = 'A4'
      displayPrintInfo(
        $DisplayAreaContents.find(sSvgPageNo + viewPage)[0].getAttribute('sheetname'),
        paperName,
        $DisplayAreaContents.find(sSvgPageNo + viewPage)[0].getAttribute('orientation')
      )
      return true
    } catch (e) {
      setError(ErrorResources.InternalException)
    }
  }
  function report(documentcontainerId, resolve, reject) {
    var result = false
    clear()
    while (true) {
      if (
        documentcontainerId == idViewerContainer ||
        parameterStringCheck(documentcontainerId) == false
      ) {
        setError(ErrorResources.IlleagalOperation)
        break
      }
      var textValue = getInlineDocument(documentcontainerId)
      if (isError()) break
      var svgText = convertTextToDocument(textValue)
      if (isError()) break
      result = true
      break
    }
    if (result == true) result = setSvgDocument(svgText)
    var tmr = setTimeout(function () {
      if (result == true) resolve != undefined && resolve()
      else reject != undefined && reject()
    }, 100)
  }
  function reportUri(uri, token, userid, resolve, reject) {
    clear()
    displayAnimation(true)
    resolveMethod = resolve
    rejectMethod = reject
    var xhr = new XMLHttpRequest()
    xhr.open('GET', uri, true)
    if (token) {
      xhr.setRequestHeader('token', token)
      xhr.setRequestHeader('userid', userid)
    }
    xhr.responseType = 'blob'
    xhr.onload = function () {
      svgBlob = this.response
      readerBinary.readAsArrayBuffer(svgBlob)
      displayAnimation(false)
    }
    xhr.onerror = function () {
      setError(ErrorResources.UriNotfound)
      invokeRejectMethod()
      displayAnimation(false)
    }
    xhr.send()
  }
  //base64ToBlob
  function base64ToBlob(base64, mimeType) {
    const byteCharacters = atob(base64)
    const byteArrays = []

    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
      const slice = byteCharacters.slice(offset, offset + 512)
      const byteNumbers = new Array(slice.length)

      for (let i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i)
      }

      const byteArray = new Uint8Array(byteNumbers)
      byteArrays.push(byteArray)
    }

    return new Blob(byteArrays, { type: mimeType })
  }

  //SHOU ADD
  function reportPriview(svgBlobIn, resolve, reject) {
    clear()
    displayAnimation(true)
    resolveMethod = resolve
    rejectMethod = reject
    const xlsxmimetype = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
    svgBlob = base64ToBlob(svgBlobIn, xlsxmimetype)
    readerBinary.readAsArrayBuffer(svgBlob)
    displayAnimation(false)
  }

  function setMinimumLineWeight(weight) {
    minimumLineWeight = 0
    if (isNaN(parseFloat(weight)) == false) {
      var weightwork = parseFloat(weight)
      if (weightwork > 0 || weightwork <= 1) minimumLineWeight = weightwork
    }
  }
  function setToolBarVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityToolBar = visibility == true
    controlUI()
  }
  function setOpenMenuButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityOpenMenuButton = visibility == true
    controlUI()
  }
  function setPageSize(isPageSize) {
    if (isBooleanValue(isPageSize) == false) return
    applyPageSize = isPageSize == true
  }
  function setPrintMenuButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPrintMenuButton = visibility == true
    controlUI()
  }
  function setSaveMenuButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilitySaveMenuButton = visibility == true
    controlUI()
  }
  function setPrintAllButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPrintAllButton = visibility == true
    controlUI()
  }
  function setPrintCurrentButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPrintCurrentButton = visibility == true
    controlUI()
  }
  function setSaveSvgAllButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilitySaveSvgAllButton = visibility == true
    controlUI()
  }
  function setSaveSvgCurrentButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilitySaveSvgCurrentButton = visibility == true
    controlUI()
  }
  function setSaveExcelButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilitySaveExcelButton = visibility == true
    controlUI()
  }
  function setSavePdfButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilitySavePdfButton = visibility == true
    controlUI()
  }
  function setPageFirstButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPageFirstButton = visibility == true
    controlUI()
  }
  function setPagePrevButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPagePrevButton = visibility == true
    controlUI()
  }
  function setPageNextButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPageNextButton = visibility == true
    controlUI()
  }
  function setPageLastButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityPageLastButton = visibility == true
    controlUI()
  }
  function setZoomButtonVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityZoomButton = visibility == true
    controlUI()
  }
  function setZoomSelectVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityZoomSelect = visibility == true
    controlUI()
  }
  function setStatusBarVisibility(visibility) {
    if (isBooleanValue(visibility) == false) return
    visibilityStatusBar = visibility == true
    controlUI()
  }
  function setError(errorValue) {
    internalError = errorValue
    $viewerContents.find(sStatusIcon).css('visibility', isError() ? '' : 'hidden')
    if (internalError.message[viewerLocale] == undefined)
      $viewerContents.find(sStatusLabel).val(internalError.message[defaultViewerLocale])
    else $viewerContents.find(sStatusLabel).val(internalError.message[viewerLocale])
    return !isError()
  }
  function setItemEnabled(item, enabled) {
    if (enabled == true) $viewerContents.find(item).prop('disabled', false)
    else $viewerContents.find(item).prop('disabled', true)
  }
  function setItemDisplayNone(item, visibled) {
    $viewerContents.find(item).css('display', visibled ? '' : 'none')
  }
  function setItemTitle(item, value) {
    $viewerContents.find(item).prop('title', value)
  }
  function setPageNo(pageNo) {
    if (pageNo < 1 || pageNo > parseInt(totalPage)) return setError(ErrorResources.IllegalOperation)
    viewPage = pageNo
    if (playPage() == false) return
    judgmentPageButtons()
    controlUI()
    return true
  }
  function setPageZoom(value) {
    if (value > 0) {
      if (value <= 20) value = 20
      if (value >= 600) value = 600
      pageZoom = value
      internalPageZoom = value
    } else if (value == -1 || value == -2 || value == -3) {
      var svgWidth = 0,
        svgHeight = 0,
        viewBoxIndex = 0
      $DisplayAreaContents
        .find(sSvgPageNo + viewPage)[0]
        .getAttribute('viewBox')
        .split(' ')
        .forEach(function (viewBoxValue) {
          viewBoxIndex++
          if (viewBoxIndex == 3) svgWidth = parseFloat(viewBoxValue)
          if (viewBoxIndex == 4) svgHeight = parseFloat(viewBoxValue)
        })
      internalPageZoom = value
      if (svgWidth == 0) svgWidth = 595.2756
      if (svgHeight == 0) svgHeight = 841.8898
      svgWidth = (svgWidth * 4) / 3
      svgHeight = (svgHeight * 4) / 3
      switch (value) {
        case -1:
          value = Math.floor((iframeHeight / svgHeight) * 100)
          if (value > Math.floor((iframeWidth / svgWidth) * 100))
            value = Math.floor((iframeWidth / svgWidth) * 100)
          break
        case -2:
          value = Math.floor((iframeWidth / svgWidth) * 100)
          break
        case -3:
          value = Math.floor((iframeHeight / svgHeight) * 100)
          break
      }
      pageZoom = value
    } else return setError(ErrorResources.IllegalOperation)
    return true
  }
  function setSaveExcelFileName(fileName) {
    saveExcelFileName = adjustFileName(fileName)
  }
  function setSavePdfFileName(fileName) {
    savePdfFileName = adjustFileName(fileName)
  }
  function setSaveSvgFileName(fileName) {
    saveSvgFileName = adjustFileName(fileName)
  }
  function setSvgDocument(value) {
    try {
      if (value == undefined) {
        isError() && setError(ErrorResources.UnsupportedDocument)
        return false
      }
      $DisplayAreaContents.find(sSvgContainer).html(value)
      var minimumLineWeightWork = minimumLineWeight
      if (getBrowserType() == 'ie' && minimumLineWeightWork < 0.6) minimumLineWeightWork = 0.6
      if (minimumLineWeightWork > 0)
        try {
          $DisplayAreaContents.find('symbol').each(function (i) {
            $(this)
              .find('rect')
              .each(function (j) {
                while (true) {
                  var target = $(this),
                    attrValue = target.attr('width')
                  if (attrValue != undefined)
                    if (parseFloat(attrValue) < minimumLineWeightWork) {
                      target.attr('width', minimumLineWeightWork)
                      break
                    }
                  attrValue = target.attr('height')
                  if (attrValue != undefined)
                    if (parseFloat(attrValue) < minimumLineWeightWork) {
                      target.attr('height', minimumLineWeightWork)
                      break
                    }
                  break
                }
              })
          })
        } catch (e) {}
      totalPage = parseInt($DisplayAreaContents.find(sSvgTotalPage).text())
      if (isNaN(totalPage) == true) totalPage = 0
      $viewerContents.find(sLabelTotalPage).val('/ ' + totalPage)
      if (totalPage > 0) {
        viewPage = 1
        if (playPage() == false) return false
      } else return setError(ErrorResources.UnsupportedDocument)
      if (svgBlob == undefined) svgTextDocument = value
      validPrintButton = true
      validSaveSvgButton = true
      validSaveExcelButton = isExistsFileItem(sSvgExcelData)
      validSavePdfButton = isExistsFileItem(sSvgPdfData)
      validZoomInButton = true
      validZoomOutButton = true
      validZoom = true
      judgmentPageButtons()
      judgmentZoomButtons()
      controlUI()
      return true
    } catch (e) {
      return setError(ErrorResources.InternalException)
    }
  }
  CellReport.Viewer.prototype.report = function (documentcontainerId, resolve, reject) {
    report(documentcontainerId, resolve, reject)
  }
  CellReport.Viewer.prototype.reportUri = function (uri, resolve, reject) {
    reportUri(uri, resolve, reject)
  }
  CellReport.Viewer.prototype.reportPriview = function (svgBlob, resolve, reject) {
    reportPriview(svgBlob, resolve, reject)
  }
  CellReport.Viewer.prototype.getErrorMessage = function () {
    return getErrorMessage()
  }
  CellReport.Viewer.prototype.setPageNo = function (pageNo) {
    setPageNo(pageNo)
  }
  CellReport.Viewer.prototype.setPageZoom = function (value) {
    if (setPageZoom(value) == true) {
      playPage()
      switch (value) {
        case -1:
          $parentContents.find(sOptionZoom1).text($viewerContents.find(sOptionZoom3).text())
          break
        case -2:
          $parentContents.find(sOptionZoom1).text($viewerContents.find(sOptionZoom4).text())
          break
        case -3:
          $parentContents.find(sOptionZoom1).text($viewerContents.find(sOptionZoom5).text())
          break
        default:
          $parentContents.find(sOptionZoom1).text(pageZoom + '%')
      }
      judgmentZoomButtons()
      controlUI()
    }
  }
  CellReport.Viewer.prototype.saveExcel = function () {
    executeSaveExcel()
  }
  CellReport.Viewer.prototype.savePdf = function () {
    executeSavePdf()
  }
  CellReport.Viewer.prototype.print = function (pageNo) {
    executePrint(pageNo)
  }
  CellReport.Viewer.prototype.setSaveExcelFileName = function (fileName) {
    setSaveExcelFileName(fileName)
  }
  CellReport.Viewer.prototype.setSavePdfFileName = function (fileName) {
    setSavePdfFileName(fileName)
  }
  CellReport.Viewer.prototype.setToolBarVisibility = function (visibility) {
    setToolBarVisibility(visibility)
  }
  CellReport.Viewer.prototype.setMinimumLineWeight = function (weight) {
    setMinimumLineWeight(weight)
  }
  CellReport.Viewer.prototype.setOpenMenuButtonVisibility = function (visibility) {
    setOpenMenuButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPageSize = function (isPageSize) {
    setPageSize(isPageSize)
  }
  CellReport.Viewer.prototype.setPrintMenuButtonVisibility = function (visibility) {
    setPrintMenuButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setSaveMenuButtonVisibility = function (visibility) {
    setSaveMenuButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPrintAllButtonVisibility = function (visibility) {
    setPrintAllButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPrintCurrentButtonVisibility = function (visibility) {
    setPrintCurrentButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setSaveSvgAllButtonVisibility = function (visibility) {
    setSaveSvgAllButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setSaveSvgCurrentButtonVisibility = function (visibility) {
    setSaveSvgCurrentButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setSaveExcelButtonVisibility = function (visibility) {
    setSaveExcelButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setSavePdfButtonVisibility = function (visibility) {
    setSavePdfButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPageFirstButtonVisibility = function (visibility) {
    setPageFirstButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPagePrevButtonVisibility = function (visibility) {
    setPagePrevButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPageNextButtonVisibility = function (visibility) {
    setPageNextButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setPageLastButtonVisibility = function (visibility) {
    setPageLastButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setZoomButtonVisibility = function (visibility) {
    setZoomButtonVisibility(visibility)
  }
  CellReport.Viewer.prototype.setZoomSelectVisibility = function (visibility) {
    setZoomSelectVisibility(visibility)
  }
  CellReport.Viewer.prototype.setStatusBarVisibility = function (visibility) {
    setStatusBarVisibility(visibility)
  }
}

export default { CellReport }
