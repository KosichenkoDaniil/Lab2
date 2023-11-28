using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab_2;

public partial class BankDeposits1Context : DbContext
{
    public BankDeposits1Context()
    {
    }

    public BankDeposits1Context(DbContextOptions<BankDeposits1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<DepositsView> DepositsViews { get; set; }

    public virtual DbSet<Emploee> Emploees { get; set; }

    public virtual DbSet<EmployeesBornBefore1993> EmployeesBornBefore1993s { get; set; }

    public virtual DbSet<Exchangerate> Exchangerates { get; set; }

    public virtual DbSet<Investor> Investors { get; set; }

    public virtual DbSet<InvestorsView> InvestorsViews { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-M9NBJS4\\SQLEXPRESS;Initial Catalog=BankDeposits1;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("currency");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.ToTable("deposits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Additionalconditions)
                .HasMaxLength(50)
                .HasColumnName("additionalconditions");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Mindepositamount)
                .HasColumnType("money")
                .HasColumnName("mindepositamount");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Rate)
                .HasColumnType("money")
                .HasColumnName("rate");
            entity.Property(e => e.Term).HasColumnName("term");

            entity.HasOne(d => d.Currency).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.Currencyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deposits_currency");
        });

        modelBuilder.Entity<DepositsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DepositsView");

            entity.Property(e => e.Additionalconditions)
                .HasMaxLength(50)
                .HasColumnName("additionalconditions");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Mindepositamount)
                .HasColumnType("money")
                .HasColumnName("mindepositamount");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Rate)
                .HasColumnType("money")
                .HasColumnName("rate");
            entity.Property(e => e.Term).HasColumnName("term");
        });

        modelBuilder.Entity<Emploee>(entity =>
        {
            entity.ToTable("emploees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .HasColumnName("post");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<EmployeesBornBefore1993>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeesBornBefore1993");

            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .HasColumnName("post");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Exchangerate>(entity =>
        {
            entity.ToTable("exchangerates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasColumnType("money")
                .HasColumnName("cost");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");

            entity.HasOne(d => d.Currency).WithMany(p => p.Exchangerates)
                .HasForeignKey(d => d.Currencyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_exchangerates_currency");
        });

        modelBuilder.Entity<Investor>(entity =>
        {
            entity.ToTable("investors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PassportId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passportID");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phonenumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<InvestorsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InvestorsView");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PassportId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passportID");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phonenumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.ToTable("operations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Depositamount)
                .HasColumnType("money")
                .HasColumnName("depositamount");
            entity.Property(e => e.Depositdate)
                .HasColumnType("date")
                .HasColumnName("depositdate");
            entity.Property(e => e.Depositid).HasColumnName("depositid");
            entity.Property(e => e.Emploeeid).HasColumnName("emploeeid");
            entity.Property(e => e.Investorsid).HasColumnName("investorsid");
            entity.Property(e => e.Refundamount)
                .HasColumnType("money")
                .HasColumnName("refundamount");
            entity.Property(e => e.Returndate)
                .HasColumnType("date")
                .HasColumnName("returndate");
            entity.Property(e => e.Returnstamp).HasColumnName("returnstamp");

            entity.HasOne(d => d.Deposit).WithMany(p => p.Operations)
                .HasForeignKey(d => d.Depositid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operations_deposits");

            entity.HasOne(d => d.Emploee).WithMany(p => p.Operations)
                .HasForeignKey(d => d.Emploeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operations_emploees");

            entity.HasOne(d => d.Investors).WithMany(p => p.Operations)
                .HasForeignKey(d => d.Investorsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operations_operations");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
