using BusinessLogic;

namespace Domain
{
    // ��������� ��� �������� �������� � �������������� �������� � ��������
    public class Operations : IOperations
    {
        public string Name { get; set; } // ��� �������� (��� ������)
        public string Value { get; set; } // ��������
        public int Operands { get; set; }  // ���������� ���������
        public int Priority { get; set; }  // ���������
        public string Placement { get; set; } // ��� ������, ��� ��������� ��������������� �����
        public string Type { get; set; }  // ������ ��� ����
    }
}