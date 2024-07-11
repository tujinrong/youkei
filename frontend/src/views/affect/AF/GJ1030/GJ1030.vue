<template>
  <el-container>
    <el-header>
      <el-form :model="form" :inline="true" class="demo-form-inline">
        <el-form-item label="关键字">
          <el-input v-model="form.keyword" placeholder="请输入关键字"></el-input>
        </el-form-item>
        <el-form-item label="分类">
          <el-select v-model="form.category" placeholder="请选择分类">
            <el-option label="分类1" value="category1"></el-option>
            <el-option label="分类2" value="category2"></el-option>
            <el-option label="分类3" value="category3"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="onSubmit">搜索</el-button>
          <el-button @click="onReset">重置</el-button>
        </el-form-item>
      </el-form>
    </el-header>
    <el-main>
      <el-table :data="tableData" style="width: 100%">
        <el-table-column prop="date" label="日期" width="180"></el-table-column>
        <el-table-column prop="name" label="姓名" width="180"></el-table-column>
        <el-table-column prop="address" label="地址"></el-table-column>
      </el-table>
    </el-main>
  </el-container>
</template>

<script>
import { ref } from 'vue';

export default {
  setup() {
    const form = ref({
      keyword: '',
      category: ''
    });

    const tableData = ref([
      {
        date: '2023-07-04',
        name: '张三',
        address: '北京市海淀区'
      },
      {
        date: '2023-07-05',
        name: '李四',
        address: '上海市浦东新区'
      }
    ]);

    const onSubmit = () => {
      // 在这里添加检索逻辑
      console.log('检索条件:', form.value);
    };

    const onReset = () => {
      form.value.keyword = '';
      form.value.category = '';
    };

    return {
      form,
      tableData,
      onSubmit,
      onReset
    };
  }
};
</script>

<style scoped>
.demo-form-inline .el-form-item {
  margin-right: 20px;
}
</style>
