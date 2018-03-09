﻿(function ($) {
    $(function () {
        var _uiCustomizationSettingsService = abp.services.app.uiCustomizationSettings;

        $('#Position').change(function () {
            toggleLeftMenuCustomizationSettings();
        });

        $("input[name='AllowAsideHiding'], input[name='AllowAsideMinimizing']").change(function () {
            toggleLeftMenuHideMode();
        });

        function toggleLeftMenuCustomizationSettings() {
            var position = $('#Position').val();
            if (position === "top") {
                $("input[name='FixedAside']").closest('div').slideUp('fast');
                $("input[name='AllowAsideMinimizing']").closest('div').slideUp('fast');
                $("input[name='DefaultMinimizedAside']").closest('div').slideUp('fast');
                $("input[name='AllowAsideHiding']").closest('div').slideUp('fast');
                $("#SubmenuToggle").closest('div').slideUp('fast');
                $("#DropdownSubmenuSkin").closest('div').slideUp('fast');
                $("input[name='DropdownSubmenuArrow']").closest('div').slideUp('fast');
            } else {
                $("input[name='FixedAside']").closest('div').slideDown('fast');
                $("input[name='AllowAsideMinimizing']").closest('div').slideDown('fast');
                $("input[name='DefaultMinimizedAside']").closest('div').slideDown('fast');
                $("input[name='AllowAsideHiding']").closest('div').slideDown('fast');
                $("#SubmenuToggle").closest('div').slideDown('fast');
                $("#DropdownSubmenuSkin").closest('div').slideDown('fast');
                $("input[name='DropdownSubmenuArrow']").closest('div').slideDown('fast');
            }
        }

        function toggleLeftMenuHideMode() {
            var allowAsideMinimizing = $("input[name='AllowAsideMinimizing']").is(':checked');

            if (allowAsideMinimizing) {
                $("input[name='DefaultMinimizedAside']").removeAttr('disabled');

                $("input[name='AllowAsideHiding']").prop("checked", false);
                $("input[name='AllowAsideHiding']").attr('disabled', 'disabled');

                $("input[name='DefaultHiddenAside']").prop("checked", false);
                $("input[name='DefaultHiddenAside']").attr('disabled', 'disabled');
            } else {
                $("input[name='AllowAsideHiding']").removeAttr('disabled');
                $("input[name='DefaultHiddenAside']").removeAttr('disabled');

                $("input[name='DefaultMinimizedAside']").prop("checked", false);
                $("input[name='DefaultMinimizedAside']").attr('disabled', 'disabled');
            }

            var allowAsideHiding = $("input[name='AllowAsideHiding']").is(':checked');

            if (allowAsideHiding) {
                $("input[name='DefaultHiddenAside']").removeAttr('disabled');
            } else {
                $("input[name='DefaultHiddenAside']").prop("checked", false);
                $("input[name='DefaultHiddenAside']").attr('disabled', 'disabled');
            }
        }

        toggleLeftMenuCustomizationSettings();
        toggleLeftMenuHideMode();

        $('#SaveSettingsButton').click(function () {
            _uiCustomizationSettingsService.updateUiManagementSettings({
                layout: $('#LayoutSettingsForm').serializeFormToObject(),
                header: $('#HeaderSettingsForm').serializeFormToObject(),
                menu: $('#MenuSettingsForm').serializeFormToObject(),
                footer: $('#FooterSettingsForm').serializeFormToObject()
            }).done(function () {
                window.location.reload();
            });
        });

        $('#SaveDefaultSettingsButton').click(function () {
            _uiCustomizationSettingsService.updateDefaultUiManagementSettings({
                layout: $('#LayoutSettingsForm').serializeFormToObject(),
                header: $('#HeaderSettingsForm').serializeFormToObject(),
                menu: $('#MenuSettingsForm').serializeFormToObject(),
                footer: $('#FooterSettingsForm').serializeFormToObject()
            }).done(function () {
                window.location.reload();
            });
        });

        $('#UseSystemDefaultSettings').click(function () {
            _uiCustomizationSettingsService.useSystemDefaultSettings().done(function () {
                window.location.reload();
            });
        });

    });
})(jQuery);