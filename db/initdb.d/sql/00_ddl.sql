set global time_zone = "Asia/Tokyo";

drop database if exists BOOK_RECODER;
create database BOOK_RECODER
  default character set utf8mb4
  default collate utf8mb4_unicode_ci;
set default_storage_engine = InnoDB;

use BOOK_RECODER;

create table book (
    id               int          not null auto_increment primary key,
    title            varchar(128) not null,
    author           varchar(128) not null,
    genre            varchar(128) not null,
    thought          text,
    created_at       datetime     not null default current_timestamp,
    updated_at       datetime     not null default current_timestamp,
    deleted_at       datetime              default null
);
