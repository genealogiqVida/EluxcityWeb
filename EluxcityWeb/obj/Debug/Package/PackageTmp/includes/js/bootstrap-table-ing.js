/**
 * @author zhixin wen <wenzhixin2010@gmail.com>
 * version: 1.3.0
 * https://github.com/wenzhixin/bootstrap-table/
 */

var paginaAtual = 1;
var telaAtual = "";
var limit = "25";

!function ($j) {

    'use strict';

    // TOOLS DEFINITION
    // ======================

    // it only does '%s', and return '' when arguments are undefined
    var sprintf = function (str) {
        var args = arguments,
            flag = true,
            i = 1;

        str = str.replace(/%s/g, function () {
            var arg = args[i++];

            if (typeof arg === 'undefined') {
                flag = false;
                return '';
            }
            return arg;
        });
        if (flag) {
            return str;
        }
        return '';
    };

    var getPropertyFromOther = function (list, from, to, value) {
        var result = '';
        $j.each(list, function (i, item) {
            if (item[from] === value) {
                result = item[to];
                return false;
            }
            return true;
        });
        return result;
    };

    var getFieldIndex = function (columns, field) {
        var index = -1;

        $j.each(columns, function (i, column) {
            if (column.field === field) {
                index = i;
                return false;
            }
            return true;
        });
        return index;
    };

    var getScrollBarWidth = function () {
        var inner = $j('<p/>').addClass('fixed-table-scroll-inner'),
            outer = $j('<div/>').addClass('fixed-table-scroll-outer'),
            w1, w2;

        outer.append(inner);
        $j('body').append(outer);

        w1 = inner[0].offsetWidth;
        outer.css('overflow', 'scroll');
        w2 = inner[0].offsetWidth;

        if (w1 == w2) {
            w2 = outer[0].clientWidth;
        }

        outer.remove();
        return w1 - w2;
    };

    var calculateObjectValue = function (self, name, args, defaultValue) {
        if (typeof name === 'string') {
            // support obj.func1.func2
            var names = name.split('.');

            if (names.length > 1) {
                name = window;
                $j.each(names, function (i, f) {
                    name = name[f];
                });
            } else {
                name = window[name];
            }
        }
        if (typeof name === 'object') {
            return name;
        }
        if (typeof name === 'function') {
            return name.apply(self, args);
        }
        return defaultValue;
    };

    // BOOTSTRAP TABLE CLASS DEFINITION
    // ======================

    var BootstrapTable = function (el, options) {
        this.options = options;
        this.$jel = $j(el);
        this.$jel_ = this.$jel.clone();
        this.timeoutId_ = 0;

        this.init();
    };

    BootstrapTable.DEFAULTS = {
        classes: 'table table-hover',
        height: undefined,
        undefinedText: '-',
        sortName: undefined,
        sortOrder: 'asc',
        striped: false,
        columns: [],
        data: [],
        method: 'get',
        url: undefined,
        cache: true,
        contentType: 'application/json',
        dataType: 'json',
        queryParams: function (params) { return params; },
        queryParamsType: 'limit', // undefined
        responseHandler: function (res) { return res; },
        pagination: false,
        sidePagination: 'client', // client or server
        totalRows: 0, // server side need to set
        pageNumber: 1,
        pageSize: 10,
        pageList: [25],
        search: false,
        searchAlign: 'right',
        selectItemName: 'btSelectItem',
        showHeader: true,
        showColumns: false,
        showRefresh: false,
        showToggle: false,
        smartDisplay: true,
        minimumCountColumns: 1,
        idField: undefined,
        cardView: false,
        clickToSelect: false,
        singleSelect: false,
        toolbar: undefined,
        toolbarAlign: 'right',
        checkboxHeader: true,
        sortable: true,
        maintainSelected: false,

        rowStyle: function (row, index) { return {}; },

        formatLoadingMessage: function () {
            return 'Loading, please wait... <br><br><br><img src="../includes/imagens/loading.gif">';
        },
        formatRecordsPerPage: function (pageNumber) {
            return sprintf('%s records per page', pageNumber);
        },
        formatShowingRows: function (pageFrom, pageTo, totalRows) {
            return sprintf('Showing %s the %s in %s records', pageFrom, pageTo, totalRows);
        },
        formatSearch: function () {
            return 'Search';
        },
        formatNoMatches: function () {
            return 'No records found';
        },
        formatRefresh: function () {
            return 'Refresh';
        },
        formatToggle: function () {
            return 'Toggle';
        },
        formatColumns: function () {
            return 'Colunas';
        },

        onAll: function (name, args) { return false; },
        onClickRow: function (item, $jelement) { return false; },
        onDblClickRow: function (item, $jelement) { return false; },
        onSort: function (name, order) { return false; },
        onCheck: function (row) { return false; },
        onUncheck: function (row) { return false; },
        onCheckAll: function () { return false; },
        onUncheckAll: function () { return false; },
        onLoadSuccess: function (data) { return false; },
        onLoadError: function (status) { return false; },
        onColumnSwitch: function (field, checked) { return false; },
        onPageChange: function (number, size) { return false; },
        onSearch: function (text) { return false; }
    };

    BootstrapTable.COLUMN_DEFAULTS = {
        radio: false,
        checkbox: false,
        checkboxEnabled: true,
        field: undefined,
        title: undefined,
        'class': undefined,
        align: undefined, // left, right, center
        halign: undefined, // left, right, center
        valign: undefined, // top, middle, bottom
        width: undefined,
        sortable: false,
        order: 'asc', // asc, desc
        visible: true,
        switchable: true,
        clickToSelect: true,
        formatter: undefined,
        events: undefined,
        sorter: undefined,
        cellStyle: undefined
    };

    BootstrapTable.EVENTS = {
        'all.bs.table': 'onAll',
        'click-row.bs.table': 'onClickRow',
        'dbl-click-row.bs.table': 'onDblClickRow',
        'sort.bs.table': 'onSort',
        'check.bs.table': 'onCheck',
        'uncheck.bs.table': 'onUncheck',
        'check-all.bs.table': 'onCheckAll',
        'uncheck-all.bs.table': 'onUncheckAll',
        'load-success.bs.table': 'onLoadSuccess',
        'load-error.bs.table': 'onLoadError',
        'column-switch.bs.table': 'onColumnSwitch',
        'page-change.bs.table': 'onPageChange',
        'search.bs.table': 'onSearch'
    };

    BootstrapTable.prototype.init = function () {
        this.initContainer();
        this.initTable();
        this.initHeader();
        this.initData();
        this.initToolbar();
        this.initPagination();
        this.initBody();
        this.initServer();
    };

    BootstrapTable.prototype.initContainer = function () {
        this.$jcontainer = $j([
            '<div class="bootstrap-table">',
                '<div class="fixed-table-toolbar"></div>',
                '<div class="fixed-table-container">',
                    '<div class="fixed-table-header"><table></table></div>',
                    '<div class="fixed-table-body">',
                        '<div class="fixed-table-loading">',
                            this.options.formatLoadingMessage(),
                        '</div>',
                    '</div>',
                    '<div class="fixed-table-pagination"></div>',
                '</div>',
            '</div>'].join(''));

        this.$jcontainer.insertAfter(this.$jel);
        this.$jcontainer.find('.fixed-table-body').append(this.$jel);
        this.$jcontainer.after('<div class="clearfix"></div>');
        this.$jloading = this.$jcontainer.find('.fixed-table-loading');

        this.$jel.addClass(this.options.classes);
        if (this.options.striped) {
            this.$jel.addClass('table-striped');
        }
    };

    BootstrapTable.prototype.initTable = function () {
        var that = this,
            columns = [],
            data = [];

        this.$jheader = this.$jel.find('thead');
        if (!this.$jheader.length) {
            this.$jheader = $j('<thead></thead>').appendTo(this.$jel);
        }
        if (!this.$jheader.find('tr').length) {
            this.$jheader.append('<tr></tr>');
        }
        this.$jheader.find('th').each(function () {
            var column = $j.extend({}, {
                title: $j(this).html(),
                'class': $j(this).attr('class')
            }, $j(this).data());

            columns.push(column);
        });
        this.options.columns = $j.extend([], columns, this.options.columns);
        $j.each(this.options.columns, function (i, column) {
            that.options.columns[i] = $j.extend({}, BootstrapTable.COLUMN_DEFAULTS,
                { field: i }, column); // when field is undefined, use index instead
        });

        // if options.data is setting, do not process tbody data
        if (this.options.data.length) {
            return;
        }

        this.$jel.find('tbody tr').each(function () {
            var row = {};

            // save tr's id and class
            row._id = $j(this).attr('id');
            row._class = $j(this).attr('class');

            $j(this).find('td').each(function (i) {
                var field = that.options.columns[i].field;

                row[field] = $j(this).html();
                // save td's id and class
                row['_' + field + '_id'] = $j(this).attr('id');
                row['_' + field + '_class'] = $j(this).attr('class');
            });
            data.push(row);
        });
        this.options.data = data;
    };

    BootstrapTable.prototype.initHeader = function () {
        var that = this,
            visibleColumns = [],
            html = [];

        this.header = {
            fields: [],
            styles: [],
            classes: [],
            formatters: [],
            events: [],
            sorters: [],
            cellStyles: [],
            clickToSelects: []
        };
        $j.each(this.options.columns, function (i, column) {
            var text = '',
                style = '',
                class_ = sprintf(' class="%s"', column['class']),
                order = that.options.sortOrder || column.order;

            if (!column.visible) {
                return;
            }

            style = sprintf('text-align: %s; ', column.halign ? column.halign : column.align);
            style += sprintf('vertical-align: %s; ', column.valign);
            style += sprintf('width: %spx; ', column.checkbox || column.radio ? 36 : column.width);

            visibleColumns.push(column);
            that.header.fields.push(column.field);
            that.header.styles.push(style);
            that.header.classes.push(class_);
            that.header.formatters.push(column.formatter);
            that.header.events.push(column.events);
            that.header.sorters.push(column.sorter);
            that.header.cellStyles.push(column.cellStyle);
            that.header.clickToSelects.push(column.clickToSelect);

            html.push('<th',
                column.checkbox || column.radio ?
                    sprintf(' class="bs-checkbox %s"', column['class'] || '') :
                    class_,
                sprintf(' style="%s"', style),
                '>');
            html.push(sprintf('<div class="th-inner %s">', that.options.sortable && column.sortable ?
                'sortable' : ''));

            text = column.title;
            if (that.options.sortName === column.field && that.options.sortable && column.sortable) {
                text += that.getCaretHtml();
            }

            if (column.checkbox) {
                if (!that.options.singleSelect && that.options.checkboxHeader) {
                    text = '<input name="btSelectAll" type="checkbox" />';
                }
                that.header.stateField = column.field;
            }
            if (column.radio) {
                text = '';
                that.header.stateField = column.field;
                that.options.singleSelect = true;
            }

            html.push(text);
            html.push('</div>');
            html.push('<div class="fht-cell"></div>');
            html.push('</th>');
        });

        this.$jheader.find('tr').html(html.join(''));
        this.$jheader.find('th').each(function (i) {
            $j(this).data(visibleColumns[i]);
        });
        this.$jcontainer.off('click', 'th').on('click', 'th', function (event) {
            if (that.options.sortable && $j(this).data().sortable) {
                that.onSort(event);
            }
        });

        if (!this.options.showHeader || this.options.cardView) {
            this.$jheader.hide();
            this.$jcontainer.find('.fixed-table-header').hide();
            this.$jloading.css('top', 0);
        } else {
            this.$jheader.show();
            this.$jcontainer.find('.fixed-table-header').show();
            this.$jloading.css('top', '30px');
        }

        this.$jselectAll = this.$jheader.find('[name="btSelectAll"]');
        this.$jcontainer.off('click', '[name="btSelectAll"]')
            .on('click', '[name="btSelectAll"]', function () {
                var checked = $j(this).prop('checked');
                that[checked ? 'checkAll' : 'uncheckAll']();
            });
    };

    BootstrapTable.prototype.initData = function (data, append) {
        if (append) {
            this.data = this.data.concat(data);
        } else {
            this.data = data || this.options.data;
        }
        this.options.data = this.data;

        if (this.options.sidePagination === 'server') {
            return;
        }
        this.initSort();
    };

    BootstrapTable.prototype.initSort = function () {
        var that = this,
            name = this.options.sortName,
            order = this.options.sortOrder === 'desc' ? -1 : 1,
            index = $j.inArray(this.options.sortName, this.header.fields);

        if (index !== -1) {
            this.data.sort(function (a, b) {
                var aa = a[name],
                    bb = b[name],
                    value = calculateObjectValue(that.header, that.header.sorters[index], [aa, bb]);

                if (value !== undefined) {
                    return order * value;
                }

                // Fix #161: undefined or null string sort bug.
                if (aa === undefined || aa === null) {
                    aa = '';
                }
                if (aa === undefined || bb === null) {
                    bb = '';
                }

                if (aa === bb) {
                    return 0;
                }
                if (aa < bb) {
                    return order * -1;
                }
                return order;
            });
        }
    };

    BootstrapTable.prototype.onSort = function (event) {
        var $jthis = $j(event.currentTarget),
            $jthis_ = this.$jheader.find('th').eq($jthis.index());

        this.$jheader.add(this.$jheader_).find('span.order').remove();

        if (this.options.sortName === $jthis.data('field')) {
            this.options.sortOrder = this.options.sortOrder === 'asc' ? 'desc' : 'asc';
        } else {
            this.options.sortName = $jthis.data('field');
            this.options.sortOrder = $jthis.data('order') === 'asc' ? 'desc' : 'asc';
        }
        this.trigger('sort', this.options.sortName, this.options.sortOrder);

        $jthis.add($jthis_).data('order', this.options.sortOrder)
            .find('.th-inner').append(this.getCaretHtml());

        if (this.options.sidePagination === 'server') {
            this.initServer();
            return;
        }
        this.initSort();
        this.initBody();
    };

    BootstrapTable.prototype.initToolbar = function () {
        var that = this,
            html = [],
            timeoutId = 0,
            $jkeepOpen,
            $jsearch,
            switchableCount = 0;

        this.$jtoolbar = this.$jcontainer.find('.fixed-table-toolbar').html('');

        if (typeof this.options.toolbar === 'string') {
            $j('<div class="bars pull-left"></div>')
                .appendTo(this.$jtoolbar)
                .append($j(this.options.toolbar));
        }

        // showColumns, showToggle, showRefresh
        html = ['<div class="columns columns-' + this.options.toolbarAlign + ' btn-group pull-' + this.options.toolbarAlign + '">'];

        if (this.options.showRefresh) {
            html.push(sprintf('<button class="btn btn-default" type="button" name="refresh" title="%s">',
                this.options.formatRefresh()),
                '<i class="glyphicon glyphicon-refresh icon-refresh"></i>',
                '</button>');
        }

        if (this.options.showToggle) {
            html.push(sprintf('<button class="btn btn-default" type="button" name="toggle" title="%s">',
                this.options.formatToggle()),
                '<i class="glyphicon glyphicon glyphicon-list-alt icon-list-alt"></i>',
                '</button>');
        }

        if (this.options.showColumns) {
            html.push(sprintf('<div class="keep-open %s" title="%s">',
                this.options.showRefresh || this.options.showToggle ? 'btn-group' : '',
                this.options.formatColumns()),
                '<button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">',
                '<i class="glyphicon glyphicon-th icon-th"></i>',
                ' <span class="caret"></span>',
                '</button>',
                '<ul class="dropdown-menu" role="menu">');

            $j.each(this.options.columns, function (i, column) {
                if (column.radio || column.checkbox) {
                    return;
                }
                var checked = column.visible ? ' checked="checked"' : '';

                if (column.switchable) {
                    html.push(sprintf('<li>' +
                        '<label><input type="checkbox" data-field="%s" value="%s"%s> %s</label>' +
                        '</li>', column.field, i, checked, column.title));
                    switchableCount++;
                }
            });
            html.push('</ul>',
                '</div>');
        }

        html.push('</div>');

        if (html.length > 2) {
            this.$jtoolbar.append(html.join(''));
        }

        if (this.options.showRefresh) {
            this.$jtoolbar.find('button[name="refresh"]')
                .off('click').on('click', $j.proxy(this.refresh, this));
        }

        if (this.options.showToggle) {
            this.$jtoolbar.find('button[name="toggle"]')
                .off('click').on('click', function () {
                    that.options.cardView = !that.options.cardView;
                    that.initHeader();
                    that.initBody();
                });
        }

        if (this.options.showColumns) {
            $jkeepOpen = this.$jtoolbar.find('.keep-open');

            if (switchableCount <= this.options.minimumCountColumns) {
                $jkeepOpen.find('input').prop('disabled', true);
            }

            $jkeepOpen.find('li').off('click').on('click', function (event) {
                event.stopImmediatePropagation();
            });
            $jkeepOpen.find('input').off('click').on('click', function () {
                var $jthis = $j(this);

                that.toggleColumn($jthis.val(), $jthis.prop('checked'), false);
                that.trigger('column-switch', $j(this).data('field'), $jthis.prop('checked'));
            });
        }

        if (this.options.search) {
            html = [];
            html.push(
                '<div class="pull-' + this.options.searchAlign + ' search">',
                    sprintf('<input class="form-control" type="text" placeholder="%s">',
                        this.options.formatSearch()),
                '</div>');

            this.$jtoolbar.append(html.join(''));
            $jsearch = this.$jtoolbar.find('.search input');
            $jsearch.off('keyup').on('keyup', function (event) {
                clearTimeout(timeoutId); // doesn't matter if it's 0
                timeoutId = setTimeout(function () {
                    that.onSearch(event);
                }, 500); // 500ms
            });
        }
    };

    BootstrapTable.prototype.onSearch = function (event) {
        var text = $j.trim($j(event.currentTarget).val());

        // trim search input
        $j(event.currentTarget).val(text);

        if (text === this.searchText) {
            return;
        }
        this.searchText = text;

        this.options.pageNumber = 1;
        this.initSearch();
        this.updatePagination();
        this.trigger('search', text);
    };

    BootstrapTable.prototype.initSearch = function () {
        var that = this;

        if (this.options.sidePagination !== 'server') {
            var s = this.searchText && this.searchText.toLowerCase();

            this.data = s ? $j.grep(this.options.data, function (item, i) {
                for (var key in item) {
                    key = $j.isNumeric(key) ? parseInt(key, 10) : key;
                    var value = item[key];

                    // Fix #142: search use formated data
                    value = calculateObjectValue(that.header,
                        that.header.formatters[$j.inArray(key, that.header.fields)],
                        [value, item, i], value);

                    if ($j.inArray(key, that.header.fields) !== -1 &&
                        (typeof value === 'string' ||
                        typeof value === 'number') &&
                        (value + '').toLowerCase().indexOf(s) !== -1) {
                        return true;
                    }
                }
                return false;
            }) : this.options.data;
        }
    };

    BootstrapTable.prototype.initPagination = function () {
        this.$jpagination = this.$jcontainer.find('.fixed-table-pagination');

        if (!this.options.pagination) {
            return;
        }
        var that = this,
            html = [],
            i, from, to,
            $jpageList,
            $jfirst, $jpre,
            $jnext, $jlast,
            $jnumber,
            data = this.getData();

        if (this.options.sidePagination !== 'server') {
            this.options.totalRows = data.length;
        }

        this.totalPages = 0;
        if (this.options.totalRows) {
            this.totalPages = ~~((this.options.totalRows - 1) / this.options.pageSize) + 1;
        }
        if (this.totalPages > 0 && this.options.pageNumber > this.totalPages) {
            this.options.pageNumber = this.totalPages;
        }

        this.pageFrom = (this.options.pageNumber - 1) * this.options.pageSize + 1;
        this.pageTo = this.options.pageNumber * this.options.pageSize;
        if (this.pageTo > this.options.totalRows) {
            this.pageTo = this.options.totalRows;
        }

        html.push(
            '<div class="pull-left pagination-detail">',
                '<span class="pagination-info">',
                    this.options.formatShowingRows(this.pageFrom, this.pageTo, this.options.totalRows),
                '</span>');

        html.push('<span class="page-list">');

        var pageNumber = [
            '<span class="btn-group dropup">',
            '<button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">',
            '<span class="page-size">',
            this.options.pageSize,
            '</span>',
            ' <span class="caret"></span>',
            '</button>',
            '<ul class="dropdown-menu" role="menu">'],
            pageList = this.options.pageList;

        if (typeof this.options.pageList === 'string') {
            var list = this.options.pageList.slice(1, -1).replace(/ /g, '').split(',');

            pageList = [];
            $j.each(list, function (i, value) {
                pageList.push(+value);
            });
        }

        $j.each(pageList, function (i, page) {
            if (!that.options.smartDisplay || that.options.totalRows >= page || i === 0) {
                var active = page === that.options.pageSize ? ' class="active"' : '';
                pageNumber.push(sprintf('<li%s><a href="javascript:void(0)">%s</a></li>', active, page));
            }
        });
        pageNumber.push('</ul></span>');

        html.push(this.options.formatRecordsPerPage(pageNumber.join('')));
        html.push('</span>');

        html.push('</div>',
            '<div class="pull-right pagination">',
                '<ul class="pagination">',
                    '<li class="page-first"><a href="javascript:void(0)">&lt;&lt;</a></li>',
                    '<li class="page-pre"><a href="javascript:void(0)">&lt;</a></li>');

        if (this.totalPages < 5) {
            from = 1;
            to = this.totalPages;
        } else {
            from = this.options.pageNumber - 2;
            to = from + 4;
            if (from < 1) {
                from = 1;
                to = 5;
            }
            if (to > this.totalPages) {
                to = this.totalPages;
                from = to - 4;
            }
        }
        for (i = from; i <= to; i++) {
            html.push('<li class="page-number' + (i === this.options.pageNumber ? ' active disabled' : '') + '">',
                '<a href="javascript:void(0)">', i, '</a>',
                '</li>');
        }

        html.push(
                    '<li class="page-next"><a href="javascript:void(0)">&gt;</a></li>',
                    '<li class="page-last"><a href="javascript:void(0)">&gt;&gt;</a></li>',
                '</ul>',
            '</div>');

        this.$jpagination.html(html.join(''));

        $jpageList = this.$jpagination.find('.page-list a');
        $jfirst = this.$jpagination.find('.page-first');
        $jpre = this.$jpagination.find('.page-pre');
        $jnext = this.$jpagination.find('.page-next');
        $jlast = this.$jpagination.find('.page-last');
        $jnumber = this.$jpagination.find('.page-number');

        if (this.options.pageNumber <= 1) {
            $jfirst.addClass('disabled');
            $jpre.addClass('disabled');
        }
        if (this.options.pageNumber >= this.totalPages) {
            $jnext.addClass('disabled');
            $jlast.addClass('disabled');
        }
        if (this.options.smartDisplay) {
            if (this.totalPages <= 1) {
                this.$jpagination.find('div.pagination').hide();
            }
            if (this.options.pageList.length < 2 || this.options.totalRows <= this.options.pageList[1]) {
                this.$jpagination.find('span.page-list').hide();
            }
        }
        $jpageList.off('click').on('click', $j.proxy(this.onPageListChange, this));
        $jfirst.off('click').on('click', $j.proxy(this.onPageFirst, this));
        $jpre.off('click').on('click', $j.proxy(this.onPagePre, this));
        $jnext.off('click').on('click', $j.proxy(this.onPageNext, this));
        $jlast.off('click').on('click', $j.proxy(this.onPageLast, this));
        $jnumber.off('click').on('click', $j.proxy(this.onPageNumber, this));
    };

    BootstrapTable.prototype.updatePagination = function (event) {
        // Fix #171: IE disabled button can be clicked bug.
        if (event && $j(event.currentTarget).hasClass('disabled')) {
            return;
        }

        if (!this.options.maintainSelected) {
            this.resetRows();
        }

        this.initPagination();
        if (this.options.sidePagination === 'server') {
            this.initServer();
        } else {
            this.initBody();
        }

        this.trigger('page-change', this.options.pageSize, this.options.pageNumber);
    };

    BootstrapTable.prototype.onPageListChange = function (event) {
        var $jthis = $j(event.currentTarget);

        $jthis.parent().addClass('active').siblings().removeClass('active');
        this.options.pageSize = +$jthis.text();
        this.$jtoolbar.find('.page-size').text(this.options.pageSize);
        this.updatePagination(event);
    };

    BootstrapTable.prototype.onPageFirst = function (event) {
        this.options.pageNumber = 1;
        paginaAtual = this.options.pageNumber;
        //  this.updatePagination(event);
        if (telaAtual == 'ocorrenciaadmin')
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        else if (telaAtual == 'ocorrencia')
            carregaDadosTabela(codLinha, codProduto);
        else if (telaAtual == 'produto')
            carregaDadosTabela(codLinha);
        else if (telaAtual == 'linha')
            carregaDadosTabela();
        else if (telaAtual == 'modelo')
            carregaDadosTabela(codLinha, codProduto, codPais);
        else if (telaAtual == 'perguntas')
            carregaDadosTabela();
        else if (telaAtual == 'relatoriouso')
            retornaRelatorioDeUso()
        else if (telaAtual == 'relatorioacesso')
            retornaRelatorioDeAcesso();
    };

    BootstrapTable.prototype.onPagePre = function (event) {
        this.options.pageNumber--;
        paginaAtual = this.options.pageNumber;
        //this.updatePagination(event);
        if (telaAtual == 'ocorrenciaadmin')
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        else if (telaAtual == 'ocorrencia')
            carregaDadosTabela(codLinha, codProduto);
        else if (telaAtual == 'produto')
            carregaDadosTabela(codLinha);
        else if (telaAtual == 'linha')
            carregaDadosTabela();
        else if (telaAtual == 'modelo')
            carregaDadosTabela(codLinha, codProduto, codPais);
        else if (telaAtual == 'perguntas')
            carregaDadosTabela();
        else if (telaAtual == 'relatoriouso')
            retornaRelatorioDeUso()
        else if (telaAtual == 'relatorioacesso')
            retornaRelatorioDeAcesso();
    };

    BootstrapTable.prototype.onPageNext = function (event) {
        this.options.pageNumber++;
        paginaAtual = this.options.pageNumber;
        if (telaAtual == 'ocorrenciaadmin')
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        else if (telaAtual == 'ocorrencia')
            carregaDadosTabela(codLinha, codProduto);
        else if (telaAtual == 'produto')
            carregaDadosTabela(codLinha);
        else if (telaAtual == 'linha')
            carregaDadosTabela();
        else if (telaAtual == 'modelo')
            carregaDadosTabela(codLinha, codProduto, codPais);
        else if (telaAtual == 'perguntas')
            carregaDadosTabela();
        else if (telaAtual == 'relatoriouso')
            retornaRelatorioDeUso()
        else if (telaAtual == 'relatorioacesso')
            retornaRelatorioDeAcesso();
        /// this.updatePagination(event);
    };

    BootstrapTable.prototype.onPageLast = function (event) {
        this.options.pageNumber = this.totalPages;
        paginaAtual = this.options.pageNumber;
        if (telaAtual == 'ocorrenciaadmin')
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        else if (telaAtual == 'ocorrencia')
            carregaDadosTabela(codLinha, codProduto);
        else if (telaAtual == 'produto')
            carregaDadosTabela(codLinha);
        else if (telaAtual == 'linha')
            carregaDadosTabela();
        else if (telaAtual == 'modelo')
            carregaDadosTabela(codLinha, codProduto, codPais);
        else if (telaAtual == 'perguntas')
            carregaDadosTabela();
        else if (telaAtual == 'relatoriouso')
            retornaRelatorioDeUso()
        else if (telaAtual == 'relatorioacesso')
            retornaRelatorioDeAcesso();
        // this.updatePagination(event);
    };

    BootstrapTable.prototype.onPageNumber = function (event) {
        if (this.options.pageNumber === +$j(event.currentTarget).text()) {
            return;
        }
        this.options.pageNumber = +$j(event.currentTarget).text();
        paginaAtual = this.options.pageNumber;
        if (telaAtual == 'ocorrenciaadmin')
            carregaDadosTabela(codLinha, codProduto, codModelo, codPais);
        else if (telaAtual == 'ocorrencia')
            carregaDadosTabela(codLinha, codProduto);
        else if (telaAtual == 'produto')
            carregaDadosTabela(codLinha);
        else if (telaAtual == 'linha')
            carregaDadosTabela();
        else if (telaAtual == 'modelo')
            carregaDadosTabela(codLinha, codProduto, codPais);
        else if (telaAtual == 'perguntas')
            carregaDadosTabela();
        else if (telaAtual == 'relatoriouso')
            retornaRelatorioDeUso()
        else if (telaAtual == 'relatorioacesso')
            retornaRelatorioDeAcesso();
        //this.updatePagination(event);
    };

    BootstrapTable.prototype.initBody = function (fixedScroll) {
        var that = this,
            html = [],
            data = this.getData();

        this.$jbody = this.$jel.find('tbody');
        if (!this.$jbody.length) {
            this.$jbody = $j('<tbody></tbody>').appendTo(this.$jel);
        }

        if (this.options.sidePagination === 'server') {
            data = this.data;
        }

        if (!this.options.pagination || this.options.sidePagination === 'server') {
            this.pageFrom = 1;
            this.pageTo = data.length;
        }

        for (var i = this.pageFrom - 1; i < this.pageTo; i++) {
            var item = data[i],
                style = {},
                csses = [];

            style = calculateObjectValue(this.options, this.options.rowStyle, [item, i], style);

            if (style && style.css) {
                for (var key in style.css) {
                    csses.push(key + ': ' + style.css[key]);
                }
            }

            html.push('<tr',
                sprintf(' id="%s"', item._id),
                sprintf(' class="%s"', style.classes || item._class),
                sprintf(' data-index="%s"', i),
                '>'
            );

            if (this.options.cardView) {
                html.push(sprintf('<td colspan="%s">', this.header.fields.length));
            }

            $j.each(this.header.fields, function (j, field) {
                var text = '',
                    value = item[field],
                    type = '',
                    cellStyle = {},
                    id_ = '',
                    class_ = that.header.classes[j];

                style = sprintf('style="%s"', csses.concat(that.header.styles[j]).join('; '));

                value = calculateObjectValue(that.header,
                    that.header.formatters[j], [value, item, i], value);

                // handle td's id and class
                if (item['_' + field + '_id']) {
                    id_ = sprintf(' id="%s"', item['_' + field + '_id']);
                }
                if (item['_' + field + '_class']) {
                    class_ = sprintf(' class="%s"', item['_' + field + '_class']);
                }

                cellStyle = calculateObjectValue(that.header,
                    that.header.cellStyles[j], [value, item, i], cellStyle);
                if (cellStyle.classes) {
                    class_ = sprintf(' class="%s"', cellStyle.classes);
                }
                if (cellStyle.css) {
                    csses = [];
                    for (var key in cellStyle.css) {
                        csses.push(key + ': ' + cellStyle.css[key]);
                    }
                    style = sprintf('style="%s"', csses.concat(that.header.styles[j]).join('; '));
                }

                if (that.options.columns[j].checkbox || that.options.columns[j].radio) {
                    //if card view mode bypass
                    if (that.options.cardView) {
                        return true;
                    }

                    type = that.options.columns[j].checkbox ? 'checkbox' : type;
                    type = that.options.columns[j].radio ? 'radio' : type;

                    text = ['<td class="bs-checkbox">',
                        '<input' +
                            sprintf(' data-index="%s"', i) +
                            sprintf(' name="%s"', that.options.selectItemName) +
                            sprintf(' type="%s"', type) +
                            sprintf(' value="%s"', item[that.options.idField]) +
                            sprintf(' checked="%s"', value === true ||
                                (value && value.checked) ? 'checked' : undefined) +
                            sprintf(' disabled="%s"', !that.options.columns[j].checkboxEnabled ||
                                (value && value.disabled) ? 'disabled' : undefined) +
                            ' />',
                        '</td>'].join('');
                } else {
                    value = typeof value === 'undefined' || value === null ?
                        that.options.undefinedText : value;

                    text = that.options.cardView ?
                        ['<div class="card-view">',
                            that.options.showHeader ? sprintf('<span class="title" %s>%s</span>', style,
                                getPropertyFromOther(that.options.columns, 'field', 'title', field)) : '',
                            sprintf('<span class="value">%s</span>', value),
                            '</div>'].join('') :
                        [sprintf('<td%s %s %s>', id_, class_, style),
                            value,
                            '</td>'].join('');

                    // Hide empty data on Card view when smartDisplay is set to true.
                    if (that.options.cardView && that.options.smartDisplay && value === '') {
                        text = '';
                    }
                }

                html.push(text);
            });

            if (this.options.cardView) {
                html.push('</td>');
            }

            html.push('</tr>');
        }

        // show no records
        if (!html.length) {
            /*  html.push('<tr class="no-records-found">',
                  sprintf('<td colspan="%s">%s</td>', this.header.fields.length, this.options.formatNoMatches()),
                  '</tr>');*/
        }

        this.$jbody.html(html.join(''));

        if (!fixedScroll) {
            this.$jcontainer.find('.fixed-table-body').scrollTop(0);
        }

        // click to select by column
        this.$jbody.find('> tr > td').off('click').on('click', function () {
            var $jtr = $j(this).parent();
            that.trigger('click-row', that.data[$jtr.data('index')], $jtr);
            // if click to select - then trigger the checkbox/radio click
            if (that.options.clickToSelect) {
                if (that.header.clickToSelects[$jtr.children().index($j(this))]) {
                    $jtr.find(sprintf('[name="%s"]',
                        that.options.selectItemName)).trigger('click');
                }
            }
        });
        this.$jbody.find('tr').off('dblclick').on('dblclick', function () {
            that.trigger('dbl-click-row', that.data[$j(this).data('index')], $j(this));
        });

        this.$jselectItem = this.$jbody.find(sprintf('[name="%s"]', this.options.selectItemName));
        this.$jselectItem.off('click').on('click', function (event) {
            event.stopImmediatePropagation();

            // radio trigger click event bug!
            if ($j(this).is(':radio')) {
                $j(this).prop('checked', true);
            }

            var checkAll = that.$jselectItem.filter(':enabled').length ===
                    that.$jselectItem.filter(':enabled').filter(':checked').length,
                checked = $j(this).prop('checked'),
                row = that.data[$j(this).data('index')];

            that.$jselectAll.add(that.$jselectAll_).prop('checked', checkAll);
            row[that.header.stateField] = checked;
            that.trigger(checked ? 'check' : 'uncheck', row);

            if (that.options.singleSelect) {
                that.$jselectItem.not(this).each(function () {
                    that.data[$j(this).data('index')][that.header.stateField] = false;
                });
                that.$jselectItem.filter(':checked').not(this).prop('checked', false);
            }

            that.updateSelected();
        });

        $j.each(this.header.events, function (i, events) {
            if (!events) {
                return;
            }
            // fix bug, if events is defined with namespace
            if (typeof events === 'string') {
                events = calculateObjectValue(null, events);
            }
            for (var key in events) {
                that.$jbody.find('tr').each(function () {
                    var $jtr = $j(this),
                        $jtd = $jtr.find('td').eq(i),
                        index = key.indexOf(' '),
                        name = key.substring(0, index),
                        el = key.substring(index + 1),
                        func = events[key];

                    $jtd.find(el).off(name).on(name, function (e) {
                        var index = $jtr.data('index'),
                            row = that.data[index],
                            value = row[that.header.fields[i]];

                        func(e, value, row, index);
                    });
                });
            }
        });

        this.updateSelected();
        this.resetView();
    };

    BootstrapTable.prototype.initServer = function (silent) {
        var that = this,
            data = {},
            params = {
                pageSize: this.options.pageSize,
                pageNumber: this.options.pageNumber,
                searchText: this.searchText,
                sortName: this.options.sortName,
                sortOrder: this.options.sortOrder
            };

        if (!this.options.url) {
            return;
        }

        if (this.options.queryParamsType === 'limit') {
            params = {
                limit: params.pageSize,
                offset: params.pageSize * (params.pageNumber - 1),
                search: params.searchText,
                sort: params.sortName,
                order: params.sortOrder
            };
        }
        data = calculateObjectValue(this.options, this.options.queryParams, [params], data);

        // false to stop request
        if (data === false) {
            return;
        }

        if (!silent) {
            this.$jloading.show();
        }

        $j.ajax({
            type: this.options.method,
            url: this.options.url,
            data: data,
            cache: this.options.cache,
            contentType: this.options.contentType,
            dataType: this.options.dataType,
            success: function (res) {
                res = calculateObjectValue(that.options, that.options.responseHandler, [res], res);

                var data = res;

                if (that.options.sidePagination === 'server') {
                    that.options.totalRows = res.total;
                    data = res.rows;
                }
                that.load(data);
                that.trigger('load-success', data);
            },
            error: function (res) {
                that.trigger('load-error', res.status);
            },
            complete: function () {
                if (!silent) {
                    that.$jloading.hide();
                }
            }
        });
    };

    BootstrapTable.prototype.getCaretHtml = function () {
        return ['<span class="order' + (this.options.sortOrder === 'desc' ? '' : ' dropup') + '">',
                '<span class="caret" style="margin: 10px 5px;"></span>',
            '</span>'].join('');
    };

    BootstrapTable.prototype.updateSelected = function () {
        this.$jselectItem.each(function () {
            $j(this).parents('tr')[$j(this).prop('checked') ? 'addClass' : 'removeClass']('selected');
        });
    };

    BootstrapTable.prototype.updateRows = function (checked) {
        var that = this;

        this.$jselectItem.each(function () {
            that.data[$j(this).data('index')][that.header.stateField] = checked;
        });
    };

    BootstrapTable.prototype.resetRows = function () {
        var that = this;

        $j.each(this.data, function (i, row) {
            that.$jselectAll.prop('checked', false);
            that.$jselectItem.prop('checked', false);
            row[that.header.stateField] = false;
        });
    };

    BootstrapTable.prototype.trigger = function (name) {
        var args = Array.prototype.slice.call(arguments, 1);

        name += '.bs.table';
        this.options[BootstrapTable.EVENTS[name]].apply(this.options, args);
        this.$jel.trigger($j.Event(name), args);

        this.options.onAll(name, args);
        this.$jel.trigger($j.Event('all.bs.table'), [name, args]);
    };

    BootstrapTable.prototype.resetHeader = function () {
        var that = this,
            $jfixedHeader = this.$jcontainer.find('.fixed-table-header'),
            $jfixedBody = this.$jcontainer.find('.fixed-table-body'),
            scrollWidth = this.$jel.width() > $jfixedBody.width() ? getScrollBarWidth() : 0;

        // fix #61: the hidden table reset header bug.
        if (this.$jel.is(':hidden')) {
            clearTimeout(this.timeoutId_); // doesn't matter if it's 0
            this.timeoutId_ = setTimeout($j.proxy(this.resetHeader, this), 100); // 100ms
            return;
        }

        this.$jheader_ = this.$jheader.clone(true, true);
        this.$jselectAll_ = this.$jheader_.find('[name="btSelectAll"]');

        // fix bug: get $jel.css('width') error sometime (height = 500)
        setTimeout(function () {
            $jfixedHeader.css({
                'height': '37px',
                'border-bottom': '1px solid #dddddd',
                'margin-right': 'auto !important'
            }).find('table').css('width', that.$jel.css('auto !important'))
                .html('').attr('class', that.$jel.attr('class'))
                .append(that.$jheader_);

            // fix bug: $j.data() is not working as expected after $j.append()
            that.$jheader.find('th').each(function (i) {
                that.$jheader_.find('th').eq(i).data($j(this).data());
            });

            that.$jbody.find('tr:first-child:not(.no-records-found) > *').each(function (i) {
                that.$jheader_.find('div.fht-cell').eq(i).width($j(this).innerWidth());
            });

            that.$jel.css('margin-top', -that.$jheader.height());

            // horizontal scroll event
            $jfixedBody.off('scroll').on('scroll', function () {
                $jfixedHeader.scrollLeft($j(this).scrollLeft());
            });
        });
    };

    BootstrapTable.prototype.toggleColumn = function (index, checked, needUpdate) {
        if (index === -1) {
            return;
        }
        this.options.columns[index].visible = checked;
        this.initHeader();
        this.initSearch();
        this.initPagination();
        this.initBody();

        if (this.options.showColumns) {
            var $jitems = this.$jtoolbar.find('.keep-open input').prop('disabled', false);

            if (needUpdate) {
                $jitems.filter(sprintf('[value="%s"]', index)).prop('checked', checked);
            }

            if ($jitems.filter(':checked').length <= this.options.minimumCountColumns) {
                $jitems.filter(':checked').prop('disabled', true);
            }
        }
    };

    // PUBLIC FUNCTION DEFINITION
    // =======================

    BootstrapTable.prototype.resetView = function (params) {
        var that = this,
            header = this.header;

        if (params && params.height) {
            this.options.height = params.height;
        }

        this.$jselectAll.prop('checked', this.$jselectItem.length > 0 &&
            this.$jselectItem.length === this.$jselectItem.filter(':checked').length);

        if (this.options.height) {
            var toolbarHeight = +this.$jtoolbar.children().outerHeight(true),
                paginationHeight = +this.$jpagination.children().outerHeight(true),
                height = this.options.height - toolbarHeight - paginationHeight;

            this.$jcontainer.find('.fixed-table-container').css('height', height + 'px');
        }

        if (this.options.cardView) {
            // remove the element css
            that.$jel.css('margin-top', '0');
            that.$jcontainer.find('.fixed-table-container').css('padding-bottom', '0');
            return;
        }

        if (this.options.showHeader && this.options.height) {
            this.resetHeader();
        }

        if (this.options.height && this.options.showHeader) {
            this.$jcontainer.find('.fixed-table-container').css('padding-bottom', '37px');
        }
    };

    BootstrapTable.prototype.getData = function () {
        return this.searchText ? this.data : this.options.data;
    };

    BootstrapTable.prototype.load = function (data) {
        this.initData(data);
        this.initSearch();
        this.initPagination();
        this.initBody();
    };

    BootstrapTable.prototype.append = function (data) {
        this.initData(data, true);
        this.initSearch();
        this.initPagination();
        this.initBody(true);
    };

    BootstrapTable.prototype.remove = function (params) {
        var len = this.options.data.length,
            i, row;

        if (!params.hasOwnProperty('field') || !params.hasOwnProperty('values')) {
            return;
        }

        for (i = len - 1; i >= 0; i--) {
            row = this.options.data[i];

            if (!row.hasOwnProperty(params.field)) {
                return;
            }
            if ($j.inArray(row[params.field], params.values) !== -1) {
                this.options.data.splice(i, 1);
            }
        }

        if (len === this.options.data.length) {
            return;
        }

        this.initSearch();
        this.initPagination();
        this.initBody(true);
    };

    BootstrapTable.prototype.updateRow = function (params) {
        if (!params.hasOwnProperty('index') || !params.hasOwnProperty('row')) {
            return;
        }
        $j.extend(this.data[params.index], params.row);
        this.initBody(true);
    };

    BootstrapTable.prototype.mergeCells = function (options) {
        var row = options.index,
            col = $j.inArray(options.field, this.header.fields),
            rowspan = options.rowspan || 1,
            colspan = options.colspan || 1,
            i, j,
            $jtr = this.$jbody.find('tr'),
            $jtd = $jtr.eq(row).find('td').eq(col);

        if (row < 0 || col < 0 || row >= this.data.length) {
            return;
        }

        for (i = row; i < row + rowspan; i++) {
            for (j = col; j < col + colspan; j++) {
                $jtr.eq(i).find('td').eq(j).hide();
            }
        }

        $jtd.attr('rowspan', rowspan).attr('colspan', colspan)
            .show(10, $j.proxy(this.resetView, this));
    };

    BootstrapTable.prototype.getSelections = function () {
        var that = this;

        return $j.grep(this.data, function (row) {
            return row[that.header.stateField];
        });
    };

    BootstrapTable.prototype.checkAll = function () {
        this.$jselectAll.add(this.$jselectAll_).prop('checked', true);
        this.$jselectItem.filter(':enabled').prop('checked', true);
        this.updateRows(true);
        this.updateSelected();
        this.trigger('check-all');
    };

    BootstrapTable.prototype.uncheckAll = function () {
        this.$jselectAll.add(this.$jselectAll_).prop('checked', false);
        this.$jselectItem.filter(':enabled').prop('checked', false);
        this.updateRows(false);
        this.updateSelected();
        this.trigger('uncheck-all');
    };

    BootstrapTable.prototype.destroy = function () {
        this.$jel.insertBefore(this.$jcontainer);
        $j(this.options.toolbar).insertBefore(this.$jel);
        this.$jcontainer.next().remove();
        this.$jcontainer.remove();
        this.$jel.html(this.$jel_.html())
            .attr('class', this.$jel_.attr('class') || ''); // reset the class
    };

    BootstrapTable.prototype.showLoading = function () {
        this.$jloading.show();
    };

    BootstrapTable.prototype.hideLoading = function () {
        this.$jloading.hide();
    };

    BootstrapTable.prototype.refresh = function (params) {
        if (params && params.url) {
            this.options.url = params.url;
            this.options.pageNumber = 1;
        }
        this.initServer(params && params.silent);
    };

    BootstrapTable.prototype.showColumn = function (field) {
        this.toggleColumn(getFieldIndex(this.options.columns, field), true, true);
    };

    BootstrapTable.prototype.hideColumn = function (field) {
        this.toggleColumn(getFieldIndex(this.options.columns, field), false, true);
    };


    // BOOTSTRAP TABLE PLUGIN DEFINITION
    // =======================

    var allowedMethods = [
        'getSelections', 'getData',
        'load', 'append', 'remove',
        'updateRow',
        'mergeCells',
        'checkAll', 'uncheckAll',
        'refresh',
        'resetView',
        'destroy',
        'showLoading', 'hideLoading',
        'showColumn', 'hideColumn'
    ];

    $j.fn.bootstrapTable = function (option, _relatedTarget) {
        var value;

        this.each(function () {
            var $jthis = $j(this),
                data = $jthis.data('bootstrap.table'),
                options = $j.extend({}, BootstrapTable.DEFAULTS, $jthis.data(),
                    typeof option === 'object' && option);

            if (typeof option === 'string') {
                if ($j.inArray(option, allowedMethods) < 0) {
                    throw "Unknown method: " + option;
                }

                if (!data) {
                    return;
                }

                value = data[option](_relatedTarget);

                if (option === 'destroy') {
                    $jthis.removeData('bootstrap.table');
                }
            }

            if (!data) {
                $jthis.data('bootstrap.table', (data = new BootstrapTable(this, options)));
            }
        });

        return typeof value === 'undefined' ? this : value;
    };

    $j.fn.bootstrapTable.Constructor = BootstrapTable;
    $j.fn.bootstrapTable.defaults = BootstrapTable.DEFAULTS;
    $j.fn.bootstrapTable.columnDefaults = BootstrapTable.COLUMN_DEFAULTS;
    $j.fn.bootstrapTable.methods = allowedMethods;

    // BOOTSTRAP TABLE INIT
    // =======================

    $j(function () {
        $j('[data-toggle="table"]').bootstrapTable();
    });

}(jQuery);