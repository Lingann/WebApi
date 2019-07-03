# 创建数据表
CREATE TABLE tbl_user (
    user_name VARCHAR(20),
    age INT,
    signup_date DATE
);

#插入一条数据
insert into tbl_user values('domain','28','2015-01-01');

#插入一条数据
insert into tbl_user values('fixed','21','2019-07-03');

# 从数据中查找数据
select * from tbl_user;

# 通过查询条件来查询数据
SELECT 
    *
FROM
    tbl_user
WHERE
    user_name = 'fixed';

# 通过update修改数据
update tbl_user set age = 18 where user_name = 'domain';

# 通过delete来删除数据
delete from tbl_user where user_name = 'fixed';

# 修改表的定义，添加一个字段
alter table tbl_user add email varchar(50);

# 插入一条带有email字段的数据
insert into tbl_user values('god','10000','2019-07-03','god@world.com');

SELECT user_name FROM tbl_user;