﻿(function () {
    $(function () {
        var _$notificationsTable = $('#NotificationsTable');
        var _notificationService = abp.services.app.notification;

        var _$targetValueFilterSelectionCombobox = $('#TargetValueFilterSelectionCombobox');
        _$targetValueFilterSelectionCombobox.selectpicker();

        var _appUserNotificationHelper = new app.UserNotificationHelper();

        var createNotificationReadButton = function ($td, record) {
            var $span = $('<span/>');
            var $button = $("<button/>")
                .addClass("btn btn-sm btn-primary")
                .attr("title", app.localize('SetAsRead'))
                .click(function (e) {
                    e.preventDefault();
                    setNotificationAsRead(record, function () {
                        $button.find('i')
                            .removeClass('la-circle-o')
                            .addClass('la-check');
                        $button.attr('disabled', 'disabled');
                        $td.closest("tr").addClass("notification-read");
                    });
                }).appendTo($span);

            var $i = $('<i class="la" >').appendTo($button);
            var notificationState = _appUserNotificationHelper.format(record).state;

            if (notificationState === 'READ') {
                $button.attr('disabled', 'disabled');
                $i.addClass('la-check');
            }

            if (notificationState === 'UNREAD') {
                $i.addClass('la-circle-o');
            }

            $td.append($span);
        };

        var dataTable = _$notificationsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _notificationService.getUserNotifications,
                inputFilter: function () {
                    return {
                        state: _$targetValueFilterSelectionCombobox.val()
                    };
                }
            },
            columnDefs: [
                {
                    targets: 0,
                    data: null,
                    orderable: false,
                    defaultContent: '',
                    createdCell: function (td, cellData, rowData, rowIndex, colIndex) {
                        createNotificationReadButton($(td), rowData);
                    }
                },
                {
                    targets: 1,
                    data: "notification",
                    render: function (notification, type, row, meta) {
                        var $container;
                        var formattedRecord = _appUserNotificationHelper.format(row, false);
                        var rowClass = getRowClass(formattedRecord);

                        if (formattedRecord.url && formattedRecord.url !== '#') {
                            $container = $('<a title="' + formattedRecord.text + '" href="' + formattedRecord.url + '" class="' + rowClass + '">' + abp.utils.truncateStringWithPostfix(formattedRecord.text, 120) + '</a>');
                        } else {
                            $container = $('<span title="' + formattedRecord.text + '" class="' + rowClass + '">' + abp.utils.truncateStringWithPostfix(formattedRecord.text, 120) + '</span>');
                        }

                        return $container[0].outerHTML;
                    }
                },
                {
                    targets: 2,
                    data: "creationTime",
                    render: function (creationTime, type, row, meta) {
                        var formattedRecord = _appUserNotificationHelper.format(row);
                        var rowClass = getRowClass(formattedRecord);
                        var $container = $('<span title="' + moment(creationTime).format("llll") + '" class="' + rowClass + '">' + formattedRecord.timeAgo + '</span> &nbsp;');
                        return $container[0].outerHTML;
                    }
                }
            ]
        });

        function getRowClass(formattedRecord) {
            return formattedRecord.state === 'READ' ? 'notification-read' : '';
        }

        function getNotifications() {
            dataTable.ajax.reload();
        }

        function setNotificationAsRead(userNotification, callback) {
            _appUserNotificationHelper.setAsRead(userNotification.id, function () {
                if (callback) {
                    callback();
                }
            });
        }

        function setAllNotificationsAsRead() {
            _appUserNotificationHelper.setAllAsRead(function () {
                getNotifications();
            });
        };

        function openNotificationSettingsModal() {
            _appUserNotificationHelper.openSettingsModal();
        };

        _$targetValueFilterSelectionCombobox.change(function () {
            getNotifications();
        });

        $('#RefreshNotificationTableButton').click(function (e) {
            e.preventDefault();
            getNotifications();
        });

        $('#btnOpenNotificationSettingsModal').click(function (e) {
            openNotificationSettingsModal();
        });

        $('#btnSetAllNotificationsAsRead').click(function (e) {
            e.preventDefault();
            setAllNotificationsAsRead();
        });

    });
})();