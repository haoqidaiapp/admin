var appEntry = new Vue({
    el: '#editEntry',
    data: {
        sysClinicalTrialId: 0,

        // 选择关联问题的分页
        pageRelatedIndex: 1,

        // 选择关联问题的搜索dto
        searchRelatedDto: {},

        //  选中问题的多选框容器
        checkbox: [],

        // 选择了固定项的问题列表
        select_guding_question: [],

        // 组合项目存放
        select_rule_question: [],

        // 组合项目最终列表
        select_zuhe_question: [],

        // 当前弹出选择问题窗口的是固定项还是组合项 1 固定项 、2 组合项目
        select_question_type: '',

        // 入排标准基本信息
        entryInfo: {
            SysClinicalTrialName: ""
        },

        // 选择问题列表的容器
        listRelated: [],

        // 问题类型容器
        typeList: [],

        // 当前分组已经存在问题
        exitsQuestionIds: [],

        // 列表页面的分页索引Id
        pageSize: 15
    },

    // 在 `methods` 对象中定义方法
    methods: {
        // 点击新增问题项（固定项和组合项用一个列表）
        add_question: function (type) {

            $("#ListModal").modal('show');
            this.select_question_type = type;
            this.getListRelated();
            this.getTypeList();
        },

        // 组合项编辑时对同一组问题新增规则
        add_zuhe_rule: function () {

            // 拷贝一组数据
            var arr = JSON.parse(JSON.stringify(this.select_rule_question[0]));

            // 清空答案
            $(arr).each(function (index, item) {
                item.SingleAnswer = 0;
                item.MultipleAnswer = [];
            });

            // 新增到数组中
            this.select_rule_question.push(arr);
        },

        // 点击选择问题确定
        selected_question: function () {

            // 如果是组合项，则点击保存的时候，验证当前最小选择了2个以上的问题
            if (appEntry.select_question_type == 2) {
                if (this.checkbox.length < 2) {
                    stluciabj.Msg.showInfo("新增组合项规则时候，至少选择2个以上的问题");
                    return;
                }
            }

            // 如果是固定项，则点击保存的时候，验证当前最小选择了1个以上的问题
            if (appEntry.select_question_type == 1) {
                if (this.checkbox.length < 1) {
                    stluciabj.Msg.showInfo("请至少选择1个以上的问题");
                    return;
                }
            }

            var model = JSON.stringify(this.checkbox);
            $.post('/question/getQuestionOrOption',
                {
                    ids: model
                },
                function (data) {

                    if (appEntry.select_question_type == 1) {
                        // 当前选择的类型为固定项时，将问题新增到固定项列表
                        $(data).each(function (index, item) {
                            appEntry.select_guding_question.push(item);
                        });
                    }

                    if (appEntry.select_question_type == 2) {

                        // 组合项规则数据

                        var tempArray = [];
                        // 当前选择的类型为组合项时，组装固定项数据
                        $(data).each(function (index, item) {
                            tempArray.push(item);
                        });

                        appEntry.select_rule_question.push(tempArray);
                        $("#editRule").modal('show');
                    }

                });

            this.cancel_guding_question();
        },

        // 保存规则
        saveRule: function () {
            // 将规则拷贝到数组中
            var arr = JSON.parse(JSON.stringify(this.select_rule_question));
            this.select_zuhe_question.push(arr);

            // 然后清空规数组
            this.cancel_save_rule();
        },

        // 保存规则
        cancel_save_rule: function () {
            this.select_rule_question = [];
            $("#editRule").modal('hide');
        },

        // 选择问题点击取消
        cancel_guding_question: function () {
            $("#ListModal").modal('hide');
            this.checkbox = [];
        },

        // 删除固定项的内容
        del_guding_question: function (index) {
            this.select_guding_question.splice(index, 1);
            console.log(index);
        },

        // 新增组的时候删除组合中的规则项
        del_zuhe_rule_question: function (index) {
            this.select_rule_question.splice(index, 1);
        },
        // 删除组合项目里面的单个规则
        del_zuhe_edit_question: function (topIndex, itemIndex, item) {

            //  删除组合项目前段数组中的数据
            layer.confirm('该操作会将本项规则从该组中删除，您确定继续吗？',
                {
                    btn: ['继续操作', '取消'] //按钮
                },
                function () {

                    if (appEntry.select_zuhe_question[topIndex].length < 2) {
                        layer.closeAll();
                        return stluciabj.Msg.showInfo("该组仅存一项规则，如需删除请直接删除该组。");
                    }

                    appEntry.select_zuhe_question[topIndex].splice(itemIndex, 1);

                    // 发起删除请求
                    $.post('/Question/DeleteQuestionByItemCode',
                        {
                            code: item.ItemCode
                        },
                        function () {
                            stluciabj.Msg.showSuccess();
                        });

                    layer.closeAll();
                },
                function () { });
        },
        // 删除组操作
        del_zuhe_group: function (obj, index) {

            //  删除组合项目前段数组中的数据
            layer.confirm('该操作会将本组所有的规则删除，您确定继续吗？',
                {
                    btn: ['继续操作', '取消'] //按钮
                },
                function () {
                    appEntry.select_zuhe_question.splice(index, 1);

                    // 避免id重复，折叠页面的id是用index+10拼接的
                    $("#" + (index + 10)).collapse('show');

                    // 发起删除请求
                    $.post('/Question/DeleteQuestionByGroupCode',
                        {
                            code: obj[0][0].GroupCode
                        },
                        function () {
                            stluciabj.Msg.showSuccess();
                        });
                    layer.closeAll();
                },
                function () {
                    $("#" + (index + 10)).collapse('show');
                });
        },

        // 获得问题列表
        getListRelated: function () {

            // 计算当前哪些问题已经存在
            this.getExitsQuestionId();

            var model = JSON.stringify(this.searchRelatedDto);
            var removeIds = JSON.stringify(this.exitsQuestionIds);
            $.post('/Question/GetPageList',
                {
                    pageIndex: this.pageRelatedIndex,
                    pageSize: this.pageSize,
                    model: model,
                    removeIds: removeIds
                },
                function (data) {
                    appEntry.listRelated = data.List;

                    // https://www.layui.com/demo/laypage.html
                    var laypage = layui.laypage;
                    //完整功能
                    laypage.render({
                        elem: 'pager1',
                        count: data.RecordCount,
                        curr: data.PageIndex,
                        limit: data.PageSize,
                        layout: ['count', 'prev', 'page', 'next', 'refresh', 'skip'],
                        jump: function (obj, first) {
                            if (!first) {
                                appEntry.pageRelatedIndex = obj.curr;
                                appEntry.getlistRelated();
                            }
                        }
                    });
                });
        },

        // 获得问题分类
        getTypeList: function () {
            $.get('/public/GetQuestionTypeList',
                {},
                function (data) {
                    appEntry.typeList = data;
                });
        },

        // 编辑页面的数据
        getAllData: function () {

            $.post('/Question/GetEntryData/',
                {
                    cId: this.sysClinicalTrialId
                },
                function (data) {
                    appEntry.entryInfo = data.BaseInfo;
                    appEntry.select_guding_question = data.SingleQuestion;
                    appEntry.select_zuhe_question = data.GroupQuestion;

                    // 获得当前分组中已经存在的问题id
                    appEntry.getExitsQuestionId();
                });

        },

        // 显示弹框
        showModal: function (item) {
            this.sysClinicalTrialId = item.Id;
            this.getAllData();
            $("#editInfo").modal('show');
        },

        // 获得当前临床试验中，已经选择的问题Id列表，方便弹出选择问题框的时候过滤已经存在的问题
        getExitsQuestionId: function () {
            var arr = [];

            // 先循环固定项
            $(this.select_guding_question).each(function (index, item) {
                arr.push(item.Id);
            });

            $(this.select_zuhe_question).each(function (index, item) {
                $(item).each(function (sIndex, sItem) {
                    if (sIndex == 0) {
                        $(sItem).each(function (oIndex, oItem) {
                            arr.push(oItem.Id);
                        });
                    }
                });
            });

            this.exitsQuestionIds = arr;
            return arr;
        },

        reset: function () {
            appEntry.checkbox = [];

        },
        // 保存数据
        save() {

            this.entryInfo.SysClinicalTrialId = this.sysClinicalTrialId;

            // 编辑基本信息
            var modelStrInfo = JSON.stringify(this.entryInfo);
            $.ajax({
                url: '/Question/EditInfo',
                async: false,
                type: "POST",
                data: {
                    model: modelStrInfo
                },
                success: function () {
                    stluciabj.Msg.showSuccess("保存基本信息成功！");
                }
            });

            // 编辑固定项
            var modelStrGuding = JSON.stringify(this.select_guding_question);
            $.ajax({
                url: '/Question/SaveGuDingData',
                async: false,
                type: "POST",
                data: {
                    model: modelStrGuding,
                    cid: appEntry.sysClinicalTrialId
                },
                success: function () {
                    stluciabj.Msg.showSuccess("保存固定项信息成功！");
                }
            });


            var modelStrZuhe = JSON.stringify(this.select_zuhe_question);

            // 提交基本的信息
            $.ajax({
                url: '/Question/SaveZuHeData',
                async: false,
                type: "POST",
                data: {
                    model: modelStrZuhe,
                    cid: appEntry.sysClinicalTrialId
                },
                success: function () {
                    stluciabj.Msg.showSuccess("保存组合项信息成功！");
                }
            });

            // 编辑组合项
            // 			var modelStr_zuhe = JSON.stringify(this.select_zuhe_question);
            // 			$.post('/Question/SaveZuHeData/', {
            // 					model: modelStr_zuhe,
            // 					cid: appEntry.sysClinicalTrialId
            // 				},
            // 				function() {
            // 					stluciabj.Msg.showSuccess("保存组合项信息成功！");
            // 				});

            //  $("#editInfo").modal("hide");
        }
    },
    mounted: function () {

        // 绑定窗口关闭事件
        $('#editInfo').on('hide.bs.modal', function () {
            appEntry.reset();
        });

        $('#ListModal').on('hide.bs.modal', function () {
            appEntry.reset();
        });
    }
});

